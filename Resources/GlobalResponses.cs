using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamblingBackDW.Resources
{
    public class GlobalResponses
    {

        public const string NoFoundTeams = "No existen Paises en la Base de datos";
        public const string NoFoundMatch = "No existen Partidos en la Base de datos";
        public const string IdNoGuidNull = "El Id del Pais debe ser diferente a un Guid Vacio";
        public const string IdMatchNull = "El Id del Partido debe ser diferente a un Guid Vacio";
        public const string IdSessionNotFound = "No existen Sessiones relacionadas a el codigo ingresado";
        public const string ScoreNotNull = "Debe ser igual o mayor a 0 el puntaje";
        public const string DateTimeIncorrect = "La Fecha y Hora es incorrecta";
        public const string SessionNameNull = "El Nombre de session no puede ser vacio";
        public const string PersonNameNull = "El Nombre de la persona no puede ser vacio";
        public const string IdentificationNull = "El Numero de identificacion no puede ser vacio";
        public const string SessionCodeNull = "El Codigo de session no puede ser vacio";
        public const string NoFoundMatches = "No Existen Partidos con ese ID";
        public const string NoUserMatches = "No Existen Usuario en la session";

        public const string InsertMatches = "Partido Creado Correctamente";
        public const string InsertSessionMatches = "Session Creada Correctamente, Codigo de session: ";
        public const string InsertGamblingMatches = "Apuesta Creada Correctamente";
        public const string UpdateMatches = "Partido Modificado Correctamente";
    }
}
