﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.EntityFramework;
namespace Entity.MDAL
{
    public class GOITINDAL
    {
        WEBGIAYEntities db = null;
        public GOITINDAL()
        {
            db = new WEBGIAYEntities();
        }
        public List<GOITIN> listgoitin()
        {
            return db.GOITINs.ToList();
        }
        public void addlichsumuatin(LICHSUMUATIN l)
        {            
            db.LICHSUMUATINs.Add(l);
            db.SaveChanges();
        }
        public List<LICHSUMUATIN> listalltindamua(int idmer)
        {
            return db.LICHSUMUATINs.Where(x => x.MAMERCHANT == idmer).ToList();
        }
        public List<LICHSUMUATIN>listlichsu()
        {
            return db.LICHSUMUATINs.Where(x => x.TRANGTHAI == 1).ToList();
        }
        public List<LICHSUMUATIN>listmerchantmuatin()
        {
            return db.LICHSUMUATINs.Where(x => x.TRANGTHAI == 0).ToList();
        }
        public void banhaykhong(int idmuatin,int code)
        {
            if(code==1)
            {
                LICHSUMUATIN ls = db.LICHSUMUATINs.Where(i => i.IDMUATIN == idmuatin).SingleOrDefault();
                ls.TRANGTHAI = 1;
                db.SaveChanges();
                MERCHANT mer = db.MERCHANTS.Where(m => m.MAMERCHANT == ls.MAMERCHANT).SingleOrDefault();
                mer.SOTINHIENTAI += ls.GOITIN.SOTIN;
                db.SaveChanges();
            }
            else
            {
                LICHSUMUATIN ls = db.LICHSUMUATINs.Where(i => i.IDMUATIN == idmuatin).SingleOrDefault();
                ls.TRANGTHAI = -1;
                db.SaveChanges();
            }            
        }
        public void bantat()
        {
            List<LICHSUMUATIN> ls = db.LICHSUMUATINs.ToList();
            foreach (var item in ls)
            {
                if(item.TRANGTHAI==0)
                {
                    LICHSUMUATIN l = db.LICHSUMUATINs.Find(item.IDMUATIN);
                    l.TRANGTHAI = 1;
                    db.SaveChanges();
                    MERCHANT mer = db.MERCHANTS.Where(m => m.MAMERCHANT == l.MAMERCHANT).SingleOrDefault();
                    mer.SOTINHIENTAI += l.GOITIN.SOTIN;
                    db.SaveChanges();
                }
            }
        }
    }
}