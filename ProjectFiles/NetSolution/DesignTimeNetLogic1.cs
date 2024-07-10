#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.NetLogic;
using FTOptix.Alarm;
using FTOptix.UI;
using FTOptix.NativeUI;
using FTOptix.WebUI;
using FTOptix.Recipe;
using FTOptix.EventLogger;
using FTOptix.DataLogger;
using FTOptix.SQLiteStore;
using FTOptix.Store;
using FTOptix.System;
using FTOptix.Retentivity;
using FTOptix.CoreBase;
using FTOptix.Core;
#endregion

public class DesignTimeNetLogic1 : BaseNetLogic
{
    [ExportMethod]
    public void TestLog()
    {
        // Insert code to be executed by the method
        Log.Info("mio primo log");
    }

    [ExportMethod]
    public void CreaVariabiliModello()
    {
        var numeroVariabili = LogicObject.GetVariable("NumeroVariabiliDaCreare");
        for (int i = 0; i < numeroVariabili.Value; i++) 
        {
            var miaVariabile = InformationModel.MakeVariable("Variabile" + i, OpcUa.DataTypes.Int16);
            Project.Current.Get("Model/VariabiliCreateDaScript").Add(miaVariabile);
        }
    }
}
