using ProyectoFinal.Data.Models;
using ProyectoFinal.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoFinal.Data.Services
{
    public class AlumnoService
    {
        private AppDbContext _context;
        public AlumnoService(AppDbContext context)
        {
            _context = context;

        }
        //Metodo para agregar un nuevo libro
        public void AddAlumnoWithClass(AlumnoVM alumno)
        {
            var _alumno = new Alumno()
            {
                Nombre = alumno.Nombre,
                Apellido = alumno.Apellido,
                FecNac = alumno.FecNac

            };
            _context.Alumnos.Add(_alumno);
            _context.SaveChanges();


            foreach (var id in alumno.ActividadIDs)
            {
                var _alumno_actividad = new Alumno_Actividad()
                {
                    AlumnoId = _alumno.id,
                    ActividadId = id
                };
                _context.Alumno_Actividads.Add(_alumno_actividad);
                _context.SaveChanges();
            }

            foreach (var id in alumno.MaterialIDs)
            {
                var _alumno_material = new Alumno_Material()
                {
                    AlumnoId = _alumno.id,
                    MaterialId = id
                };
                _context.Alumno_Materials.Add(_alumno_material);
                _context.SaveChanges();
            }
            foreach (var id in alumno.ConductaIDs)
            {
                var _alumno_conducta = new Alumno_Conducta()
                {
                    AlumnoId = _alumno.id,
                    ConductaId = id
                };
                _context.Alumno_Conductas.Add(_alumno_conducta);
                _context.SaveChanges();
            }
        }

        //Metodo para listar todos los libros
        public List<Alumno> GetAllAns() => _context.Alumnos.ToList();
        //Metodo para obtener el libro por id
        public AlumnoWithClassVM GetAlumnoById(int alumnoid)
        {
            var _alumnoWithClass = _context.Alumnos.Where(n => n.id == alumnoid).Select(alumno => new AlumnoWithClassVM()
            {
                Nombre = alumno.Nombre,
                Apellido = alumno.Apellido,
                ActividadNames = alumno.Alumno_Actividads.Select(n => n.Actividad.Titulo).ToList(),
                MaterialNames = alumno.Alumno_Materials.Select(n => n.Material.Nombre).ToList(),
                ConductaNames = alumno.Alumno_Conductas.Select(n => n.Conducta.CalificacionConducta).ToList()

            }).FirstOrDefault();
            return _alumnoWithClass;
        }

        //Metodo para modificar el alumno
        public Alumno UpdateAlumnoByID(int alumnoid, AlumnoVM alumno)
        {
            var _alumno = _context.Alumnos.FirstOrDefault(n => n.id == alumnoid);
            if (_alumno != null)
            {
                _alumno.Nombre = alumno.Nombre;
                _alumno.Apellido = alumno.Apellido;
                _alumno.FecNac = alumno.FecNac;

                _context.SaveChanges();
            }
            return _alumno;
        }
        //Metodo para eliminar el alumno
        public void DeleteAlumnoById(int alumnoid)
        {
            var _alumno = _context.Alumnos.FirstOrDefault(n => n.id == alumnoid);
            if (_alumno != null)
            {
                _context.Alumnos.Remove(_alumno);
                _context.SaveChanges();
            }
        }
    }
}
