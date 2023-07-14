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

    public void Insert()
    {
        var employee = _employeeView.InsertMenu();

        var result = _employeeModel.Insert(employee);
        switch (result)
        {
            case -1:
                _employeeView.Error();
                break;
            case 0:
                _employeeView.Failure();
                break;
            default:
                _employeeView.Success();
                break;
        }
    }

    public void Update()
    {
        var employee = _employeeView.UpdateMenu();
        var result = _employeeModel.Update(employee);

        switch (result)
        {
            case -1:
                _employeeView.Error();
                break;
            case 0:
                _employeeView.Failure();
                break;
            default:
                _employeeView.Success();
                break;
        }
    }

    public void Delete()
    {
        var employee = _employeeView.DeleteMenu();
        var result = _employeeModel.Delete(employee.Id);

        switch (result)
        {
            case -1:
                _employeeView.Error();
                break;
            case 0:
                _employeeView.Failure();
                break;
            default:
                _employeeView.Success();
                break;
        }
    }

    public void GetById()
    {
        var employee = _employeeView.GetByIdMenu(null);
        var result = _employeeModel.GetById(employee.Id);

        if (false)
        {
            _employeeView.DataEmpty();
        }
        else
        {
            _employeeView.GetById(result);
        }
    }
}