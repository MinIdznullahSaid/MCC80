using MVCArchitecture.Models;
using MVCArchitecture.Views;
using System.Diagnostics.Metrics;

namespace MVCArchitecture.Controllers;

public class CLocation
{
    private Location _locationModel;
    private VLocation _locationView;

    public CLocation(Location locationModel, VLocation locationView)
    {
        _locationModel = locationModel;
        _locationView = locationView;
    }

    public void GetAll()
    {
        var result = _locationModel.GetAll();
        if (result.Count is 0)
        {
            _locationView.DataEmpty();
        }
        else
        {
            _locationView.GetAll(result);
        }
    }

    public void Insert()
    {
        var location = _locationView.InsertMenu();

        var result = _locationModel.Insert(location);
        switch (result)
        {
            case -1:
                _locationView.Error();
                break;
            case 0:
                _locationView.Failure();
                break;
            default:
                _locationView.Success();
                break;
        }
    }

    public void Update()
    {
        var location = _locationView.UpdateMenu();
        var result = _locationModel.Update(location);

        switch (result)
        {
            case -1:
                _locationView.Error();
                break;
            case 0:
                _locationView.Failure();
                break;
            default:
                _locationView.Success();
                break;
        }
    }

    public void Delete()
    {
        var location = _locationView.DeleteMenu();
        var result = _locationModel.Delete(location.Id);

        switch (result)
        {
            case -1:
                _locationView.Error();
                break;
            case 0:
                _locationView.Failure();
                break;
            default:
                _locationView.Success();
                break;
        }
    }

    public void GetById()
    {
        var location = _locationView.GetByIdMenu(null);
        var result = _locationModel.GetById(location.Id);

        if (false)
        {
            _locationView.DataEmpty();
        }
        else
        {
            _locationView.GetById(result);
        }
    }
}