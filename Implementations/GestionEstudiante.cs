using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EstudiantesCore1.Entidades;
using EstudiantesCore1.interactores;
using EstudiantesInfraestructure.Database;
using Microsoft.EntityFrameworkCore;

namespace EstudiantesInfraestructure.Implementations
{
    public class GestionEstudiante : IMatricula
    {
        private readonly AppDbContext _dbcontext;
        public GestionEstudiante(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public void ActualizarEstudiante(Estudiante estudiante)
        {
            _dbcontext.Update<Estudiante>(estudiante);
            _dbcontext.SaveChanges();
        }

        public void MatricularEstudiante(Estudiante estudiante)
        {
            estudiante.estado=_dbcontext.EstadoEstudiante.Where(s=>s.codigo=="M").AsNoTracking().FirstOrDefault();
            _dbcontext.EstadoEstudiante.Find(estudiante.estado.id);
            _dbcontext.TipoDocumento.Find(estudiante.TipoDocumento.id);
            _dbcontext.Estudiante.Add(estudiante);
            _dbcontext.SaveChanges();
        }

        public Estudiante ObtenerEstudiante(int idEstudiante)
        {
            Estudiante estudiante = _dbcontext.Estudiante.Where(s => s.id == idEstudiante)
                .Include(s=>s.TipoDocumento)
                .Include(s=>s.estado).FirstOrDefault(); 
            return estudiante;
        }

        public List<EstudiantesXMateria> ObtenerMateriasEstudiante(int idEstudiante)
        {
            List<EstudiantesXMateria> materias = _dbcontext.EstudianteXMateria.Where(s=>s.estudiante.id==idEstudiante).
                Include(s=>s.estado).Include(s=>s.materia).AsNoTracking().ToList();
            return materias;
        }

        public List<Estudiante> ObtenerTodosEstudiantes(bool getall, int take, int skip)
        {
            List<Estudiante> estudiantes = new List<Estudiante>();
            var query = _dbcontext.Estudiante
                .Include(s => s.TipoDocumento)
                .Include(s => s.estado).AsNoTracking();
            if (getall)
            {
                estudiantes = query.ToList();
                if (estudiantes.Any())
                {
                    estudiantes[0].TotalCount = query.Count();
                }
            }
            else
            {
                if(take > 0)
                {
                    estudiantes=query.Skip(skip).Take(take).ToList();
                    if (estudiantes.Any())
                    {
                        estudiantes[0].TotalCount = query.Count();
                    }
                }
            }
            return estudiantes;
        }

        public void Consultas()
        {
            List<int> materiasId = new List<int> { 1,2,3};
            List<Materia> materias = (from m in _dbcontext.Materia where materiasId.Contains(m.id)
                                      select m).ToList();

        }

        public List<TipoDocumento> GetDocumentos()
        {
            List<TipoDocumento> documentos = _dbcontext.TipoDocumento.AsNoTracking().ToList();
            return documentos;
        }

        public List<EstadoEstudiante> GetEstadoEstudiantes()
        {
            List<EstadoEstudiante> estados = _dbcontext.EstadoEstudiante.AsNoTracking().ToList();

            return estados;
        }

        public bool VerificarEstudianteByDocumento(int idTipoDocumento, string documento)
        {
            bool existe = _dbcontext.Estudiante
                .Any(e => e.TipoDocumento.id==idTipoDocumento && e.documento.ToUpper()==documento);
            return existe;
        }

        public List<Materia> GetMaterias()
        {
            List<Materia> materias = _dbcontext.Materia.Include(s => s.estado).AsNoTracking().ToList();
            return materias;
        }

        public List<EstadoMateriaEstudiante> GetEstadoMaterias()
        {
            List<EstadoMateriaEstudiante> materias = _dbcontext.EstadoMateriaEstudiante.AsNoTracking().ToList();
            return materias;
        }

        public bool VerificarCodigoUnicoMateria(string codigo)
        {
            return _dbcontext.Materia.Any(s=>s.codigo.ToUpper()==codigo.ToUpper());
        }

        public void CrearNuevaMateria(Materia materia)
        {
            materia.estado = _dbcontext.EstadoMateriaEstudiante.Find(materia.estado.id);
            _dbcontext.Materia.Add(materia);
            _dbcontext.SaveChanges();
        }

        public Materia GetMateriaById(int id)
        {
            Materia materia = _dbcontext.Materia.Find(id);
            return materia;
        }

        public void ActualizarMateria(Materia materia)
        {
            if (materia.estado.id != 0)
            {
                materia.estado = _dbcontext.EstadoMateriaEstudiante.Find(materia.id);
            }
            _dbcontext.SaveChanges();
        }

        //public List<Profesor> ObtenerTodosProfesores()
        //{
        //    List<Profesor> profesores = _dbcontext.Profesor
        //        .Include(s => s.tipoDocumento)
        //        .Include(s => s.estado)
        //        .ToList();
        //    return profesores;
        //}

        //public Profesor GetProfesorbyId(int id)
        //{
        //    Profesor profesor = _dbcontext.Profesor.Where(s => s.id == id)
        //        .Include(s => s.tipoDocumento)
        //        .Include(s => s.estado).FirstOrDefault();
        //    return profesor;
        //}

        //public void ActualizarProfesor(Profesor profesor)
        //{
        //    _dbcontext.Update<Profesor>(profesor);
        //    _dbcontext.SaveChanges();
        //}

        //public List<EstadoProfesor> getEstadoProfesores()
        //{
        //    List<EstadoProfesor> profesores = _dbcontext.EstadoProfesor.AsNoTracking().ToList();
        //    return profesores;
        //}

        //public bool VerificarProfesorByDocumento(int idTipoDocumento, string documento)
        //{
        //    bool existe = _dbcontext.Profesor
        //        .Any(e => e.tipoDocumento.id == idTipoDocumento && e.documento.ToUpper() == documento);
        //    return existe;
        //}

        //public List<ProfesoresXMateria> ObtenerMateriasProfesores(int idEstudiante)
        //{
        //    throw new NotImplementedException();
        //}

        //public void CrearNuevoProfesor(Profesor profesor)
        //{
        //    profesor.estado = _dbcontext.EstadoProfesor.Find(profesor.estado.id);
        //    profesor.tipoDocumento = _dbcontext.TipoDocumento.Find(profesor.tipoDocumento.id);
        //    _dbcontext.Profesor.Add(profesor);
        //    _dbcontext.SaveChanges();
        //}
    }
}
