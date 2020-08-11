using Listado.Data;

namespace Listado.Model
{
    using SQLite;
    public class Tarea : BaseModel, ITable
    {
        private int id;
        private bool isCompleted;
        private string titulo;
        private string descripcion;

        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get => id; set
            {
                id = value;
                NotifyPropertyChanged();
            }
        }
        public bool IsCompleted
        {
            get => isCompleted; set
            {
                isCompleted = value;
                NotifyPropertyChanged();
            }
        }

        public string Titulo
        {
            get => titulo; set
            {
                titulo = value;
                NotifyPropertyChanged();
            }
        }
        public string Descripcion
        {
            get => descripcion; set
            {
                descripcion = value;
                NotifyPropertyChanged();
            }
        }
    }
}
