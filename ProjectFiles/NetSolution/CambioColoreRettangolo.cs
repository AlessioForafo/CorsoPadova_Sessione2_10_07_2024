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

public class CambioColoreRettangolo : BaseNetLogic
{
    private IUAVariable miaVariabile;

    public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started
        miaVariabile = Project.Current.GetVariable("Model/VariabiliCreateDaScript/Variabile0");
        miaVariabile.VariableChange += MiaVariabile_VariableChange;
    }

    private void MiaVariabile_VariableChange(object sender, VariableChangeEventArgs e)
    {
        var mioRettangolo = (Rectangle)Owner;
        if (e.NewValue > 20)
            mioRettangolo.FillColor = Colors.Red;
        else
            mioRettangolo.FillColor = Colors.Lime;
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
        miaVariabile.VariableChange -= MiaVariabile_VariableChange;
    }
}
