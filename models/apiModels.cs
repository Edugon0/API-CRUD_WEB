namespace WebApplication1.Models;

public class ApiModel{ 
    public ApiModel(String name) { 
        Name = name;
        Id = Guid.NewGuid();
    }

    public Guid  Id{ get; init; }
    public string Name{ get; private set; }

    public void ChangeName(string name){
        Name = name;
    }

    public void SetInactive(){
        Name = "desativado";
    }

}