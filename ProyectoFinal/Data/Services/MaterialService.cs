using ProyectoFinal.Data.Models;
using ProyectoFinal.Data.ViewModel;
using System;
using System.Linq;

namespace ProyectoFinal.Data.Services
{
    public class MaterialService
    {
        private AppDbContext _context;
        public MaterialService(AppDbContext context)
        {
            _context = context;

        }
        //Metodo para agregar un nuevo Material
        public void AddMaterial(MaterialVM material)
        {
            var _material = new Material()
            {
                Nombre = material.Nombre,
                Descripcion = material.Descripcion
            };
            _context.Materials.Add(_material);
            _context.SaveChanges();
        }

        public MaterialWithAlumnoVM GetMaterialWithAlumno(int materialId)
        {
            var _material = _context.Materials.Where(n => n.Id == materialId).Select(n => new MaterialWithAlumnoVM()
            {
                Nombre = n.Nombre,
                AlumnoName = n.Alumno_Materials.Select(n => n.Alumno.Nombre).ToList()
            }).FirstOrDefault();
            return _material;
        }

        //Metodo para modificar el material
        public Material UpdateMaterialByID(int materialid, MaterialVM material)
        {
            var _material = _context.Materials.FirstOrDefault(n => n.Id == materialid);
            if (_material != null)
            {
                _material.Nombre = material.Nombre;
                _material.Descripcion = material.Descripcion;

                _context.SaveChanges();
            }
            return _material;
        }

        //Metodo para eliminar el libre
        public void DeleteMaterialById(int materialid)
        {
            var _material = _context.Materials.FirstOrDefault(n => n.Id == materialid);
            if (_material != null)
            {
                _context.Materials.Remove(_material);
                _context.SaveChanges();
            }
        }
    }
}
