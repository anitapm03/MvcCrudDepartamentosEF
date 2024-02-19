using MvcCrudDepartamentosEF.Data;
using MvcCrudDepartamentosEF.Models;

namespace MvcCrudDepartamentosEF.Repositories
{
    public class RepositoryDepartamentos
    {
        private DepartamentoContext context;

        public RepositoryDepartamentos(DepartamentoContext context)
        {
            this.context = context;
        }   

        public List<Departamento> GetDepartamentos()
        {
            var consulta = from datos in this.context.Departamentos
                           select datos;
            return consulta.ToList();
        }

        public Departamento FindDepartamento(int idDepartamento)
        {
            var consulta = from datos in this.context.Departamentos
                           where datos.IdDepartamento == idDepartamento
                           select datos;

            return consulta.FirstOrDefault();
        }

        public void EliminarDepartamento(int idDepartamento)
        {
            Departamento dept = this.FindDepartamento(idDepartamento);
            this.context.Departamentos.Remove(dept);
            this.context.SaveChanges();
        }

        public void InsertarDepartamento
            (int idDepartamento, string nombre, string loc)
        {
            Departamento dept = new Departamento();
            dept.IdDepartamento = idDepartamento;
            dept.Nombre = nombre;
            dept.Loc = loc;

            this.context.Departamentos.Add(dept);
            this.context.SaveChanges();
        }

        public void ModificarDepartamento
            (int idDepartamento, string nombre, string loc)
        {
            Departamento dept = this.FindDepartamento(idDepartamento);
            
            dept.Nombre = nombre;
            dept.Loc = loc;

            this.context.SaveChanges();
        }
    }
}
