using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksEvaluation.Core.Mapper
{
    public interface IBaseMapper<TSourse,Tdestination>
    {
        Tdestination MapModel(TSourse source);
        IEnumerable<Tdestination>MapList(IEnumerable<TSourse> source);
    }
}
