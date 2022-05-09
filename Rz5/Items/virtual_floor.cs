using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using NewMethod;

namespace Rz5
{
    public partial class virtual_floor : virtual_floor_auto
    {
        //List<virtual_desk> m_Desks = null;
        //public List<virtual_desk> Desks
        //{
        //    get
        //    {
        //        if (m_Desks == null)
        //        {
        //            m_Desks = new List<virtual_desk>();
        //            ArrayList a = xSys.QtC("virtual_desk", "select * from virtual_desk where the_virtual_floor_uid = '" + unique_id + "'");
        //            foreach (virtual_desk d in a)
        //            {
        //                m_Desks.Add(d);
        //                d.GatherRecentActivity(SysRz4.Context);
        //            }
        //        }
        //        return m_Desks;
        //    }
        //}

        //public virtual_desk AddDesk(NewMethod.n_user u)
        //{
        //    virtual_desk d = new virtual_desk(xSys);
        //    d.the_virtual_floor_uid = this.unique_id;
        //    d.the_n_user_uid = u.unique_id;
        //    d.name = u.name;
        //    d.job_desc = u.job_desc;
        //    if (!Tools.Strings.StrExt(d.job_desc))
        //        d.job_desc = "Sales";
        //    d.ISave();
        //    m_Desks.Add(d);
        //    return d;
        //}
    }
}
