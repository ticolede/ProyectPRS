using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfProyectPRS
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IInitialize" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IInitialize
    {
        [OperationContract]
        ResponseJson CheckRoundMoves(int idGame, int idRound);

        [OperationContract]
        ResponseJson NewGame();

        [OperationContract]
        ResponseJson GetGameDetailScore(int idPlayer);

        [OperationContract]
        ResponseJson GetGamePlayersMove(int idGame);

        [OperationContract]
        ResponseJson GetMoves();

        [OperationContract]
        ResponseJson NewMove(int idGame, int idMove, int idPlayer, int idRound);

        [OperationContract]
        ResponseJson NewPlayer(string player,int idPlayer = 0);

        [OperationContract]
        ResponseJson GetPlayersGame();

        [OperationContract]
        ResponseJson Logs(string service, string input, string output);

        [OperationContract]
        ResponseJson LogError(string exception);

    }
}
