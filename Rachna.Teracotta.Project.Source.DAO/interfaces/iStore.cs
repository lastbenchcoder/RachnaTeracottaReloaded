using Rachna.Teracotta.Project.Source.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rachna.Teracotta.Project.Source.DAO.interfaces
{
    public interface iStore
    {
        Stores Create(Stores stores);
        List<Stores> List();
        Stores Detail(int store_id);
        Stores Update(Stores stores);
        List<Stores_Audit> AuditList();
    }
}
