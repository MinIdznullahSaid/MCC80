using MVCArchitecture.Models;
using MVCArchitecture.Views;
using System.Diagnostics.Metrics;

namespace MVCArchitecture.Controllers;

public class CHistory
{
    private History _historyModel;
    private VHistory _historyView;

    public CHistory(History historyModel, VHistory historyView)
    {
        _historyModel = historyModel;
        _historyView = historyView;
    }

    public void GetAll()
    {
        var result = _historyModel.GetAll();
        if (result.Count is 0)
        {
            _historyView.DataEmpty();
        }
        else
        {
            _historyView.GetAll(result);
        }
    }

    public void Insert()
    {
        var history = _historyView.InsertMenu();

        var result = _historyModel.Insert(history);
        switch (result)
        {
            case -1:
                _historyView.Error();
                break;
            case 0:
                _historyView.Failure();
                break;
            default:
                _historyView.Success();
                break;
        }
    }

    public void Update()
    {
        var history = _historyView.UpdateMenu();
        var result = _historyModel.Update(history);

        switch (result)
        {
            case -1:
                _historyView.Error();
                break;
            case 0:
                _historyView.Failure();
                break;
            default:
                _historyView.Success();
                break;
        }
    }

    public void Delete()
    {
        var history = _historyView.DeleteMenu();
        var result = _historyModel.Delete(history.EmployeeId);

        switch (result)
        {
            case -1:
                _historyView.Error();
                break;
            case 0:
                _historyView.Failure();
                break;
            default:
                _historyView.Success();
                break;
        }
    }

    public void GetById()
    {
        var history = _historyView.GetByIdMenu(null);
        var result = _historyModel.GetById(history.EmployeeId);

        if (false)
        {
            _historyView.DataEmpty();
        }
        else
        {
            _historyView.GetById(result);
        }
    }
}