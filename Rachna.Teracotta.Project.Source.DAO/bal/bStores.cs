using Rachna.Teracotta.Project.Source.Common.Entities;
using Rachna.Teracotta.Project.Source.DAO.Helper;
using Rachna.Teracotta.Project.Source.DAO.interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Rachna.Teracotta.Project.Source.DAO.bal
{
    public class bStores
    {
        iStore _store;
        public bStores(iStore store)
        {
            _store = store;
        }
        public  Stores Create(Stores stores)
        {
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Stores", "New Store " + stores.Store_Name +
                    "( " + stores.Store_Id + "  and " + stores.StoreCode + " ) created successfully.",
                    1, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "New Store Created", mailBody, "Rachna Teracotta : Activity Admin");
            }
            return _store.Create(stores);
        }

        public  List<Stores> List()
        {
            return _store.List();
        }

        public  Stores Update(Stores stores)
        {
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Stores", "Store Updation done on " + stores.Store_Name +
                    "( " + stores.Store_Id + "  and " + stores.StoreCode + " ) successfully.",
                    1, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "Store Updation", mailBody, "Rachna Teracotta : Activity Admin");
            }
            return _store.Update(stores);
        }

        public  List<Stores_Audit> AuditList()
        {
            return _store.AuditList();
        }

        public Stores Detail(int store_id)
        {
            return _store.Detail(store_id);
        }
    }
}