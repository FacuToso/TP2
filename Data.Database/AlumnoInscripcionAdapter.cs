using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class AlumnoInscripcionAdapter : Adapter
    {
        public List<AlumnoInscripcion> GetAll()
        {
            List<AlumnoInscripcion> inscripcion = new List<AlumnoInscripcion>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdInscripcion = new SqlCommand("select * from alumnos_inscripciones", sqlConn);

                SqlDataReader drInscripcion = cmdInscripcion.ExecuteReader();

                while (drInscripcion.Read())
                {
                    AlumnoInscripcion ins = new AlumnoInscripcion();

                    ins.ID = (int)drInscripcion["id_inscripcion"];
                    ins.IDAlumno = (int)drInscripcion["id_alumno"];
                    ins.IDCurso = (int)drInscripcion["id_curso"];
                    ins.Condicion = (string)drInscripcion["condicion"];
                    ins.Nota = (int)drInscripcion["nota"];

                    inscripcion.Add(ins);
                }

                drInscripcion.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Erro al recuperar lista de Alumnos inscriptos", Ex);

                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return inscripcion;
        }


        //public int GetOneByDesc(string descripcion)

        //{
        //    int Id;
        //    try
        //    {
        //        this.OpenConnection();

        //        SqlCommand cmdMateria = new SqlCommand("select id_materia from MATERIAS where desc_materia = @descripcion ", sqlConn);
        //        cmdMateria.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = descripcion;

        //        Id = Convert.ToInt32(cmdMateria.ExecuteScalar());




        //    }
        //    catch (Exception Ex)
        //    {
        //        Exception ExcepcionManejada =
        //            new Exception("Erro al recuperar lista de Materias", Ex);

        //        throw ExcepcionManejada;
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }

        //    return Id;

        //}


        public Business.Entities.AlumnoInscripcion GetOne(int ID)
        {
            AlumnoInscripcion ins = new AlumnoInscripcion();
            try
            {
                this.OpenConnection();

                SqlCommand cmdInscripcion = new SqlCommand("select * from alumnos_inscripciones where id_inscripcion = @id", sqlConn);
                cmdInscripcion.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drInscripcion = cmdInscripcion.ExecuteReader();

                if (drInscripcion.Read())
                {
                    ins.ID = (int)drInscripcion["id_inscripcion"];
                    ins.IDAlumno = (int)drInscripcion["id_alumno"];
                    ins.IDCurso = (int)drInscripcion["id_curso"];
                    ins.Condicion = (string)drInscripcion["condicion"];
                    ins.Nota = (int)drInscripcion["nota"];
                }
                drInscripcion.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de Inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return ins;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete =
                    new SqlCommand("delete alumnos_inscripciones where id_inscripcion= @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar inscripcion", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        protected void Update(AlumnoInscripcion inscripcion)
        {
            try
            {
                this.OpenConnection();
                //CAPAS QUE HAY ERROR ACA NO ESTA REVISADO
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE alumnos_inscripciones SET id_alumno = @id_alumno, id_curso = @id_curso, condicion = @condicion, nota = @nota " +
                    "WHERE id_inscripcion = @id", sqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = inscripcion.ID;
                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = inscripcion.IDAlumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = inscripcion.IDCurso;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar,50).Value = inscripcion.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = inscripcion.Nota;
                cmdSave.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos de inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(AlumnoInscripcion inscripcion)
        {
            try
            {
                this.OpenConnection();
                // PUEDE HABER ERRORES ACA , HAY QUE REVISAR
                SqlCommand cmdSave = new SqlCommand(
                    "insert into alumnos_inscripciones(id_alumno,id_curso,condicion,nota)" +
                    "values (@id_alumno,@id_curso,@condicion,@nota)" +
                    "select @@identity",
                    sqlConn);


                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = inscripcion.IDAlumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = inscripcion.IDCurso;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar,50).Value = inscripcion.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = inscripcion.Nota;
                inscripcion.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //Asi se obtiene el id desde la base de datos
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear inscripcion", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(AlumnoInscripcion inscripcion)
        {
            if (inscripcion.State == BusinessEntity.States.Deleted)
            {
                this.Delete(inscripcion.ID);
            }
            else if (inscripcion.State == BusinessEntity.States.New)
            {
                this.Insert(inscripcion);
            }
            else if (inscripcion.State == BusinessEntity.States.Modified)
            {
                this.Update(inscripcion);
            }
            inscripcion.State = BusinessEntity.States.Unmodified;
        }
    }
}

