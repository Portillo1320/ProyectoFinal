﻿using ProyectoFinal.Data.Models;
using ProyectoFinal.Data.ViewModel;
using System;
using System.Collections.Generic;
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
        // Método para agregar un nuevo Material
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

        // Método para listar todos los Materiales con alumnos relacionados
        public List<MaterialWithAlumnoVM> GetAllAns()
        {
            return _context.Materials.Select(n => new MaterialWithAlumnoVM
            {
                Nombre = n.Nombre,
                Descripcion = n.Descripcion,
                AlumnoName = n.Alumno_Materials.Select(a => a.Alumno.Nombre).ToList()
            }).ToList();
        }

        // Método para obtener un material por ID con alumnos relacionados
        public MaterialWithAlumnoVM GetMaterialWithAlumno(int materialId)
        {
            var _material = _context.Materials.Where(n => n.Id == materialId).Select(n => new MaterialWithAlumnoVM()
            {
                Nombre = n.Nombre,
                Descripcion = n.Descripcion,
                AlumnoName = n.Alumno_Materials.Select(n => n.Alumno.Nombre).ToList()
            }).FirstOrDefault();
            return _material;
        }

        // Método para modificar el material
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

        // Método para eliminar el material
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

