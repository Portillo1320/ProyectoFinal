using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Data.Models;
using ProyectoFinal.Data.Services;
using ProyectoFinal.Data.ViewModel;
using System;
using System.Collections.Generic;
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

        // Método para listar todas las actividades con alumnos relacionados
        public List<ActividadWithAlumnoVM> GetAllAns()
        {
            return _context.Actividads.Select(n => new ActividadWithAlumnoVM
            {
                Id = n.Id, 
                Titulo = n.Titulo,
                Descripcion = n.Descripcion,
                Fecha = n.Fecha,
                AlumnoName = n.Alumno_Actividads.Select(a => a.Alumno.Nombre).ToList()
            }).ToList();
        }

        // Método para agregar una nueva actividad
        public void AddActividad(ActividadVM actividad)
        {
            var _actividad = new Actividad
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
            var _actividad = _context.Actividads.Where(n => n.Id == actividadId)
                .Select(n => new ActividadWithAlumnoVM
                {
                    Id = n.Id, 
                    Titulo = n.Titulo,
                    Descripcion = n.Descripcion,
                    Fecha = n.Fecha,
                    AlumnoName = n.Alumno_Actividads.Select(a => a.Alumno.Nombre).ToList()
                }).FirstOrDefault();

            return _actividad;
        }

        // Método para modificar la actividad
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

        // Método para eliminar la actividad
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


