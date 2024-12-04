using ProyectoFinal.Data.Models;
using ProyectoFinal.Data.ViewModel;
using System;
using System.Linq;

namespace ProyectoFinal.Data.Services
{
    public class ActividadService
    {
        private AppDbContext _context;
        public ActividadService(AppDbContext context)
        {
            _context = context;

        }
        //Metodo para agregar un nuevo libro
        public void AddActividad(ActividadVM actividad)
        {
            var _actividad = new Actividad()
            {
                Titulo = actividad.Titulo,
                Descripcion = actividad.Descripcion,
                Fecha = actividad.Fecha
            };
            _context.Actividads.Add(_actividad);
            _context.SaveChanges();
        }

        public ActividadWithAlumnoVM GetActividadWithAlumno(int actividadId)
        {
            var _actividad = _context.Actividads.Where(n => n.Id == actividadId).Select(n => new ActividadWithAlumnoVM()
            {
                Titulo = n.Titulo,
                AlumnoName = n.Alumno_Actividads.Select(n => n.Alumno.Nombre).ToList()
            }).FirstOrDefault();
            return _actividad; 
        }

        //Metodo para modificar el actividad
        public Actividad UpdateActivivdadByID(int actividadid, ActividadVM actividad)
        {
            var _actividad = _context.Actividads.FirstOrDefault(n => n.Id == actividadid);
            if (_actividad != null)
            {
                _actividad.Titulo = actividad.Titulo;
                _actividad.Descripcion = actividad.Descripcion;
                _actividad.Fecha = actividad.Fecha;

                _context.SaveChanges();
            }
            return _actividad;
        }

        //Metodo para eliminar el libre
        public void DeleteActividadById(int actividadid)
        {
            var _actividad = _context.Actividads.FirstOrDefault(n => n.Id == actividadid);
            if (_actividad != null)
            {
                _context.Actividads.Remove(_actividad);
                _context.SaveChanges();
            }
        }
    }
}
