using ProyectoFinal.Data.Models;
using ProyectoFinal.Data.ViewModel;
using System;
using System.Collections.Generic;
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

        // Método para agregar una nueva Conducta
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

        // Método para listar todas las conductas con alumnos relacionados
        public List<ConductaWithAlumnoVM> GetAllAns() 
        {
            var allConducta = _context.Conductas.Select(n => new ConductaWithAlumnoVM 
            {
                CalificacionConducta = n.CalificacionConducta,
                Observaciones = n.Observaciones,
                Fecha = n.Fecha,
                AlumnoName = n.Alumno_Conductas.Select(ac => ac.Alumno.Nombre).ToList()
            }).ToList();

            return allConducta;
        }

        public ConductaWithAlumnoVM GetConductaWithAlumno(int conductaId) 
        {
            var _conducta = _context.Conductas
                .Where(n => n.Id == conductaId)
                .Select(n => new ConductaWithAlumnoVM 
                {
                    CalificacionConducta = n.CalificacionConducta,
                    AlumnoName = n.Alumno_Conductas.Select(n => n.Alumno.Nombre).ToList()
                }).FirstOrDefault();

            return _conducta;
        }

        // Método para modificar la conducta
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

        // Método para eliminar la conducta
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

