using MVCArchitecture.Models;
using MVCArchitecture.Views;
using System.Diagnostics.Metrics;

namespace MVCArchitecture.Controllers;

public class CDepartement
{
    private Departement _departementModel;
    private VDepartement _departementView;

    public CDepartement(Departement departementModel, VDepartement departementView)
    {
        _departementModel = departementModel;
        _departementView = departementView;
    }

    public void GetAll()
    {
        var result = _departementModel.GetAll();
        if (result.Count is 0)
        {
            _departementView.DataEmpty();
        }
        else
        {
            _departementView.GetAll(result);
        }
    }

    public void Insert()
    {
        var departement = _departementView.InsertMenu();

        var result = _departementModel.Insert(departement);
        switch (result)
        {
            case -1:
                _departementView.Error();
                break;
            case 0:
                _departementView.Failure();
                break;
            default:
                _departementView.Success();
                break;
        }
    }

    public void Update()
    {
        var departement = _departementView.UpdateMenu();
        var result = _departementModel.Update(departement);

        switch (result)
        {
            case -1:
                _departementView.Error();
                break;
            case 0:
                _departementView.Failure();
                break;
            default:
                _departementView.Success();
                break;
        }
    }

    public void Delete()
    {
        var departement = _departementView.DeleteMenu();
        var result = _departementModel.Delete(departement.Id);

        switch (result)
        {
            case -1:
                _departementView.Error();
                break;
            case 0:
                _departementView.Failure();
                break;
            default:
                _departementView.Success();
                break;
        }
    }

    public void GetById()
    {
        var departement = _departementView.GetByIdMenu(null);
        var result = _departementModel.GetById(departement.Id);

        if (false)
        {
            _departementView.DataEmpty();
        }
        else
        {
            _departementView.GetById(result);
        }
    }
}