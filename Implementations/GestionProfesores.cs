using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EstudiantesCore1.Entidades;
using EstudiantesCore1.Interface;
using EstudiantesInfraestructure.Database;
using Microsoft.EntityFrameworkCore;

namespace EstudiantesInfraestructure.Implementations
{
    public class GestionProfesores : IGestionProfesores
    {
        private readonly AppDbContext _dbcontext;
        public GestionProfesores(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public void ActualizarProfesor(Profesor profesor)
        {
            _dbcontext.Update<Profesor>(profesor);
            _dbcontext.SaveChanges();
        }

        public void CrearNuevoProfesor(Profesor profesor)
        {
            profesor.estado = _dbcontext.EstadoProfesor.Find(profesor.estado.id);
            profesor.tipoDocumento = _dbcontext.TipoDocumento.Find(profesor.tipoDocumento.id);
            _dbcontext.Profesor.Add(profesor);
            _dbcontext.SaveChanges();
        }

        public List<EstadoProfesor> getEstadoProfesores()
        {
            List<EstadoProfesor> profesores = _dbcontext.EstadoProfesor.AsNoTracking().ToList();
            return profesores;
        }

        public Profesor GetProfesorbyId(int id)
        {
            Profesor profesor = _dbcontext.Profesor.Where(s => s.id == id)
                .Include(s => s.tipoDocumento)
                .Include(s => s.estado).FirstOrDefault();
            return profesor;
        }

        public List<ProfesoresXMateria> ObtenerMateriasProfesores(int idEstudiante)
        {
            throw new NotImplementedException();
        }

        public List<Profesor> ObtenerTodosProfesores()
        {
            List<Profesor> profesores = _dbcontext.Profesor
                .Include(s => s.tipoDocumento)
                .Include(s => s.estado)
                .ToList();
            return profesores;
        }

        public bool VerificarProfesorByDocumento(int idTipoDocumento, string documento)
        {
            bool existe = _dbcontext.Profesor
                .Any(e => e.tipoDocumento.id == idTipoDocumento && e.documento.ToUpper() == documento);
            return existe;
        }

        public List<TipoDocumento> GetDocumentos()
        {
            List<TipoDocumento> documentos = _dbcontext.TipoDocumento.AsNoTracking().ToList();
            return documentos;
        }
    }
}
