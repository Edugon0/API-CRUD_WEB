using Microsoft.EntityFrameworkCore;
using WebApplication1.data;
using WebApplication1.Models;

namespace WebApplication1.Routes;

public static class apiRoute{
    public static void apiRoutes(this WebApplication app){
        var route = app.MapGroup("WebApplication1"); // Isso ajuda a não escrever a sua rota, pq essa variavel ja armazena qual rota vc teve ir

        route.MapPost("", async(apiRequest req, apiContext context)=>{
            var user = new ApiModel( req.name);
            await context.AddAsync(user);
            await context.SaveChangesAsync();
        });

        route.MapGet("", async(apiContext context)=>{
            var users = await context.Username.ToListAsync();
            return Results.Ok(users);
        });

        route.MapPut("{id:guid}", async(Guid id, apiRequest req, apiContext context)=>{
            var user = await context.Username.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return Results.NotFound();

            user.ChangeName(req.name);
            await context.SaveChangesAsync();
            return Results.Ok(user);
        });

        route.MapDelete("{id:guid}", async(Guid id, apiContext context)=>{
            var user = await context.Username.FirstOrDefaultAsync(x => x.Id == id);
             if (user == null)
                return Results.NotFound();
            
            user.SetInactive();
            await context.SaveChangesAsync();
            return Results.Ok(user);

        });
    }
}