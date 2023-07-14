using MVCArchitecture.Models;
using MVCArchitecture.Views;
using System.Diagnostics.Metrics;

namespace MVCArchitecture.Controllers;

public class CEmployee
{
    private Employee _employeeModel;
    private VEmployee _employeeView;

    public CEmployee(Employee employeeModel, VEmployee employeeView)
    {
        _employeeModel = employeeModel;
        _employeeView = employeeView;
    }

    public void GetAll()
    {
        var result = _employeeModel.GetAll();
        if (result.Count is 0)
        {
            _employeeView.DataEmpty();
        }
        else
        {
            _employeeView.GetAll(result);
        }
    }

  /*  public void Insert()
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
    }*/
}