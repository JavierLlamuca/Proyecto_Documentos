using Proyecto_Documentos.Datos;
using Proyecto_Documentos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Documentos.Logica
{
    public class Miembros_Logica
    {
        public Miembros_Datos datos;

        public Miembros_Logica()
        {
            this.datos = new Miembros_Datos();
        }


        public List<Miembro> GetMiemrbros()
        {
            return datos.GetMiembros();
        }

        public List<Miembro> GetMiembrosActa(int idConsejo)
        {
            return datos.GetMiembrosActa(idConsejo);
        }

        public List<Miembro> GetCoordinadoresCarrera()
        {
            return datos.GetCoordinadoresCarrera();
        }

        public Miembro GetMiembroById(string id)
        {
            return datos.GetMiembrosById(id);
        }
        public int InsertMiembro(Miembro m)
        {
            return datos.InsertMiembro(m);
        }
        public int UpdateMiembro(Miembro m)
        {
            return datos.UpdateMiembro(m);
        }
        public int DeleteMiembro(Miembro m)
        {
            return datos.DeleteMiembro(m);
        }
        public int GetIDporCedula(string id)
        {
            return datos.GetIDporCedula(id);
        }


    }
}