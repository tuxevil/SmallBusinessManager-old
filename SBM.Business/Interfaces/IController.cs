using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SBM.Business.Interfaces
{
    public interface IController<T,IdT>
    {
        //T Create(params string[]);
        List<T> GetAll();
        T Get(IdT id);
        List<T> Get(string search);
        T GetFromItem(XElement item);
        List<T> GetFromItem(List<XElement> items);
        void SaveOrUpdate(T o);
        void Erase(T o);
    }
}
