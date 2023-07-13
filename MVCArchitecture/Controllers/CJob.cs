using MVCArchitecture.Models;
using MVCArchitecture.Views;
using System.Diagnostics.Metrics;

namespace MVCArchitecture.Controllers;

public class CJob
{
    private Job _jobModel;
    private VJob _jobView;

    public CJob(Job jobModel, VJob jobView)
    {
        _jobModel = jobModel;
        _jobView = jobView;
    }

    public void GetAll()
    {
        var result = _jobModel.GetAll();
        if (result.Count is 0)
        {
            _jobView.DataEmpty();
        }
        else
        {
            _jobView.GetAll(result);
        }
    }

    public void Insert()
    {
        var job = _jobView.InsertMenu();

        var result = _jobModel.Insert(job);
        switch (result)
        {
            case -1:
                _jobView.Error();
                break;
            case 0:
                _jobView.Failure();
                break;
            default:
                _jobView.Success();
                break;
        }
    }

    public void Update()
    {
        var job = _jobView.UpdateMenu();
        var result = _jobModel.Update(job);

        switch (result)
        {
            case -1:
                _jobView.Error();
                break;
            case 0:
                _jobView.Failure();
                break;
            default:
                _jobView.Success();
                break;
        }
    }

    public void Delete()
    {
        var job = _jobView.DeleteMenu();
        var result = _jobModel.Delete(job.Id);

        switch (result)
        {
            case -1:
                _jobView.Error();
                break;
            case 0:
                _jobView.Failure();
                break;
            default:
                _jobView.Success();
                break;
        }
    }

    public void GetById()
    {
        var job = _jobView.GetByIdMenu(null);
        var result = _jobModel.GetById(job.Id);

        if (false)
        {
            _jobView.DataEmpty();
        }
        else
        {
            _jobView.GetById(result);
        }
    }
}