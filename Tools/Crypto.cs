using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class Crypto
    {

        public class PasswordHasher
        {
            //Primary Resource for actual code, found this method very readable / understandable
            //https://medium.com/@mehanix/lets-talk-security-salted-password-hashing-in-c-5460be5c3aae

            //USeful Resources:
            //https://www.codeproject.com/Articles/704865/Salted-Password-Hashing-Doing-it-Right
            //https://www.dotnetperls.com/rngcryptoserviceprovider
            //https://csharp.hotexamples.com/examples/-/RNGCryptoServiceProvider/-/php-rngcryptoserviceprovider-class-examples.html
            //https://www.codeproject.com/Tips/1156169/Encrypt-Strings-with-Passwords-AES-SHA - Primary resource for AES technique
            //https://www.thesslstore.com/blog/difference-encryption-hashing-salting/ - Good primer on differences between Encryption and hashing / salting


            //Global variables                
            static string UserProvidedPassword;
            //static int Iterations = 20000; //min of 10000 recommended  source: https://cryptosense.com/blog/parameter-choice-for-pbkdf2/
            static int Iterations = 1000;
            static int SaltLength = 32;
            static int HashLength = 32;

            public static string CreatePasswordHash(string password)
            {
                UserProvidedPassword = password;
                return CreatePasswordHash();
                //3.Save both the hash and salt to the user’s database record.
                //For now saving the complete string in one cell, will extract the salt from it later.                

            }

            private static string CreatePasswordHash()
            {
                try
                {

                    //1. Generate a long random salt using a CSPRNG.
                    //make a byte[]
                    byte[] salt;
                    //16 of the overall bits will be the salt
                    new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltLength]);

                    //2.Concatenate the password to the salt and hash it using PBKDF2                
                    var pbkdf2 = new Rfc2898DeriveBytes(UserProvidedPassword, salt, Iterations);

                    //populate the byte array with pseudo-random numbers equal to the HashLength (that's what getbytes does)
                    byte[] hash = pbkdf2.GetBytes(HashLength);

                    //make new byte array to store the hashed password + salt - i.e. 32 + 32 = total of 64 bytes
                    byte[] hashBytes = new byte[SaltLength + HashLength];

                    //place the hash and salt in their respective places
                    //the salt can technically go anywhere.  Here we're putting it into the 1st 16 bytes (prepending)
                    //why 36? becayse 20 for the hash, and 15 for the salt
                    //Per the above, use the saltLenght and HashLength variables correctly to calculate array lengths
                    Array.Copy(salt, 0, hashBytes, 0, SaltLength);//salt will start at pos 0 and copy 'SaltLength' bytes
                    Array.Copy(hash, 0, hashBytes, SaltLength, HashLength);//hash will start at pos 16, copy 'HashLength'
                                                                           //now convert the byte array to a string
                    string passwordSaltAndHash = Convert.ToBase64String(hashBytes);

                    return passwordSaltAndHash;
                }
                catch (Exception e)
                {
                    //Console.WriteLine("Error: {0}", e.Message);
                    return null;
                }
            }

            public static bool ValidatePasswordHash(string password, string hash)
            {
                UserProvidedPassword = password;
                return ValidatePasswordHash(hash);

            }

            private static bool ValidatePasswordHash(string databaseSavedSaltAndHashedString)
            {
                try
                {


                    //1.Retrieve the user’s salt and hash from the DB.   
                    //Get the hashed Value (includes salt) from database           
                    //string databaseSavedSaltAndHashedString = "t7XfGMaKVxpY1tz4o8S+l0MlgmCgIke7Z9somvDS9DK8SM5ABWtMCUj7f0jYjkDa6TiqJggjyxY+KeKKRoglMA=="; // = "farts"
                    //string databaseSavedSaltAndHashedString = "+dOE4iXLD9vSfttv6/FMGFdFmiM8MR34nK5oW3M5bbv0gH++wW+sIrXKh6tOx3/Gnh4L+B53Ama1yz+8lQjJ8g=="; // = toots
                    byte[] hashBytes = Convert.FromBase64String(databaseSavedSaltAndHashedString);


                    //2.Concatenate the entered password to the salt and hash it.
                    //Take the salt out of the string, remember from before, we opted for the 1st 16 bits to be salt.
                    byte[] arrSalt = new byte[SaltLength];
                    //Take the 'SaltLength' bytes from 'hashBytes', put them in arrSalt
                    Array.Copy(hashBytes, 0, arrSalt, 0, SaltLength);

                    //hash the user inputted password with the salt we pulled from the DB, be sure to use same iterations here, etc.
                    var pbkdf2 = new Rfc2898DeriveBytes(UserProvidedPassword, arrSalt, Iterations);

                    //put the hashed input in a byte array so we can compare it byte-by-byte
                    byte[] arrHashResult = pbkdf2.GetBytes(HashLength);

                    //3.Compare the hashed password in the DB with the entered one. If they match, grant access.
                    //compare the results, byte by byte, starting from 16, because 0-15 are the salt  
                    bool success = true;
                    for (int i = 0; i < HashLength; i++)
                    {
                        // hashBtes[i+16] is telling it to start at 16, and keep checking (20 times, per the for parameter above), this is just the hash form our salt+hash database string.
                        if (hashBytes[i + HashLength] != arrHashResult[i])
                        {
                            success = false;
                            //Break out on any fail
                            break;
                        }
                    }
                    return success;
                }
                catch (Exception e)
                {
                    //Console.WriteLine("Error: {0}", e.Message);
                    return false;
                }
            }



        }
    }
}
