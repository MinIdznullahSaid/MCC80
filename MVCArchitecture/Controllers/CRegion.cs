using MVCArchitecture.Models;
using MVCArchitecture.Views;

namespace MVCArchitecture.Controllers;

public class CRegion
{
    private Region _regionModel;
    private VRegion _regionView;

    public CRegion(Region regionModel, VRegion regionView)
    {
        _regionModel = regionModel;
        _regionView = regionView;
    }

    public void GetAll()
    {
        var result = _regionModel.GetAll();
        if (result.Count is 0)
        {
            _regionView.DataEmpty();
        }
        else
        {
            _regionView.GetAll(result);
        }
    }

    public void Insert()
    {
        var region = _regionView.InsertMenu();

        var result = _regionModel.Insert(region);
        switch (result)
        {
            case -1:
                _regionView.Error();
                break;
            case 0:
                _regionView.Failure();
                break;
            default:
                _regionView.Success();
                break;
        }
    }

    public void Update()
    {
        var region = _regionView.UpdateMenu();
        var result = _regionModel.Update(region);

        switch (result)
        {
            case -1:
                _regionView.Error();
                break;
            case 0:
                _regionView.Failure();
                break;
            default:
                _regionView.Success();
                break;
        }
    }

    public void Delete()
    {
        var region = _regionView.DeleteMenu();
        var result = _regionModel.Delete(region.Id);

        switch (result)
        {
            case -1:
                _regionView.Error();
                break;
            case 0:
                _regionView.Failure();
                break;
            default:
                _regionView.Success();
                break;
        }
    }

    public void GetById()
    {
        var region = _regionView.GetByIdMenu(null);
        var result = _regionModel.GetById(region.Id);

        if (false)
        {
            _regionView.DataEmpty();
        }
        else
        {
            _regionView.GetById(result);
        }
    }
}