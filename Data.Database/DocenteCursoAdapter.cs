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
    public class DocenteCursoAdapter : Adapter
    {
        public List<DocenteCurso> GetAll()
        {
            List<DocenteCurso> docenteCursos = new List<DocenteCurso>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdDocenteCursos = new SqlCommand("select * from docentes_cursos", sqlConn);

                SqlDataReader drDocenteCursos = cmdDocenteCursos.ExecuteReader();

                while (drDocenteCursos.Read())
                {
                    DocenteCurso doc = new DocenteCurso();

                    doc.ID = (int)drDocenteCursos["id_dictado"];
                    doc.IDCurso = (int)drDocenteCursos["id_curso"];
                    doc.IDDocente = (int)drDocenteCursos["id_docente"];
                    doc.Cargo = (DocenteCurso.TiposCargos)(int)drDocenteCursos["cargo"];
                   

                    docenteCursos.Add(doc);
                }

                drDocenteCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Erro al recuperar lista de Dictados", Ex);

                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return docenteCursos;
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


        public Business.Entities.DocenteCurso GetOne(int ID)
        {
            DocenteCurso doc = new DocenteCurso();
            try
            {
                this.OpenConnection();

                SqlCommand cmdDocenteCursos = new SqlCommand("select * from docentes_cursos where id_dictado = @id", sqlConn);
                cmdDocenteCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drDocenteCursos = cmdDocenteCursos.ExecuteReader();

                if (drDocenteCursos.Read())
                {
                    doc.ID = (int)drDocenteCursos["id_dictado"];
                    doc.IDCurso = (int)drDocenteCursos["id_curso"];
                    doc.IDDocente = (int)drDocenteCursos["id_docente"];
                    doc.Cargo = (DocenteCurso.TiposCargos)(int)drDocenteCursos["cargo"];
                }
                drDocenteCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de Cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return doc;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete =
                    new SqlCommand("delete docentes_cursos where id_dictado = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        protected void Update(DocenteCurso docenteCursos)
        {
            try
            {
                this.OpenConnection();
                //CAPAS QUE HAY ERROR ACA NO ESTA REVISADO
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE docentes_cursos SET id_curso = @id_curso, id_docente = @id_docente, cargo = @cargo " +
                    "WHERE id_dictado = @id", sqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = docenteCursos.ID;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = docenteCursos.IDCurso;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = docenteCursos.IDDocente;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = docenteCursos.Cargo;
                cmdSave.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos de la cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(DocenteCurso docenteCursos)
        {
            try
            {
                this.OpenConnection();
                // PUEDE HABER ERRORES ACA , HAY QUE REVISAR
                SqlCommand cmdSave = new SqlCommand(
                    "insert into docentes_cursos(id_curso,id_docente,cargo)" +
                    "values (@id_curso,@id_docente,@cargo)" +
                    "select @@identity",
                    sqlConn);


                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = docenteCursos.IDCurso;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = docenteCursos.IDDocente;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = docenteCursos.Cargo;
                docenteCursos.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //Asi se obtiene el id desde la base de datos
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear dictado", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(DocenteCurso docenteCursos)
        {
            if (docenteCursos.State == BusinessEntity.States.Deleted)
            {
                this.Delete(docenteCursos.ID);
            }
            else if (docenteCursos.State == BusinessEntity.States.New)
            {
                this.Insert(docenteCursos);
            }
            else if (docenteCursos.State == BusinessEntity.States.Modified)
            {
                this.Update(docenteCursos);
            }
            docenteCursos.State = BusinessEntity.States.Unmodified;
        }
    }
}
