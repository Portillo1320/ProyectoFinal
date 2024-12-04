using ProyectoFinal.Data.Models;
using ProyectoFinal.Data.ViewModel;
using System;
using System.Linq;

namespace ProyectoFinal.Data.Services
{
    public class ConductaService
    {
        private AppDbContext _context;
        public ConductaService(AppDbContext context)
        {
            _context = context;

        }
        //Metodo para agregar un nuevo Conducta
        public void AddConducta(ConductaVM conducta)
        {
            var _conducta = new Conducta()
            {
                Observaciones = conducta.Observaciones,
                CalificacionConducta = conducta.CalificacionConducta,
                Fecha = conducta.Fecha
            };
            _context.Conductas.Add(_conducta);
            _context.SaveChanges();
        }

        public ConductaWithAlumnoVM GetConductaWithAlumno(int conductaId)
        {
            var _conducta = _context.Conductas.Where(n => n.Id == conductaId).Select(n => new ConductaWithAlumnoVM()
            {
                CalificacionConducta = n.CalificacionConducta,
                AlumnoName = n.Alumno_Conductas.Select(n => n.Alumno.Nombre).ToList()
            }).FirstOrDefault();
            return _conducta;
        }

        //Metodo para modificar el conducta
        public Conducta UpdateConductaByID(int conductaid, ConductaVM conducta)
        {
            var _conducta = _context.Conductas.FirstOrDefault(n => n.Id == conductaid);
            if (_conducta != null)
            {
                _conducta.Observaciones = conducta.Observaciones;
                _conducta.CalificacionConducta = conducta.CalificacionConducta;
                _conducta.Fecha = conducta.Fecha;

                _context.SaveChanges();
            }
            return _conducta;
        }

        //Metodo para eliminar el alumno
        public void DeleteConductaById(int conductaid)
        {
            var _conducta = _context.Conductas.FirstOrDefault(n => n.Id == conductaid);
            if (_conducta != null)
            {
                _context.Conductas.Remove(_conducta);
                _context.SaveChanges();
            }
        }
    }
}
