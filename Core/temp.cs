
//using System.Collections;
//using System.Collections.Generic;
//namespace test
//{
//    public class Zoo
//    {
//        ArrayList Animals = new ArrayList();

//        public void Fill()
//        {
//            Animals.Add(new Dog());
//            Animals.Add(new Cat());

//            foreach (Animal a in Animals)
//                a.Speak();
//        }

//    }

//    public abstract class Animal
//    {
//        public abstract void Speak();

//        public virtual int LegCount
//        {
//            get
//            {
//                return 4;
//            }
//        }
//    }

//    public class Dog : Animal
//    {
//        public override void Speak()
//        {
//            Bark();
//        }

//        void Bark()
//        {

//        }
//    }

//    public class Cat : Animal
//    {
//        public override void Speak()
//        {
//            //base.Speak();
//            Meow();
//        }

//        void Meow()
//        {

//        }
//    }

//    public class Fish : Animal
//    {
//        public override int LegCount
//        {
//            get
//            {
//                return 0;
//            }
//        }

//        public override void Speak()
//        {
            
//        }
//    }
//}
