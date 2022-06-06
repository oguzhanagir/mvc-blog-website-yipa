using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        List<T> List(); //Listeleme Methodu

        int Insert(T p);    //Ekleme Methodu

        int Update(T p);    //Güncelleme Methodu
        int Delete(T p);    //Silme Methodu
        T GetByID(int id);  //ID ye Göre Bilgi Getirme
        List<T> List(Expression<Func<T, bool>> where);  //ExpressionFunc Göre Listeleme Methodu
        T Find(Expression<Func<T, bool>> where);    //ExpressionFunc Göre Find MEthodu

        
    }
}
