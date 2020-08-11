using System;
using System.Collections.Generic;
using System.Text;

namespace Listado.Data
{
   public interface ITable
    {
        int Id { get; set; }
        bool IsCompleted { get; set; }
    }
}
