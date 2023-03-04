using HomeSwapTravel.Domain.Entities;
using HomeSwapTravel.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HomeSwapTravel.Infrastructure.Persistence;

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default roles
        var administratorRole = new IdentityRole("Administrator");

        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
        }

        var homeOwnerRole = new IdentityRole("HomeOwner");

        if (_roleManager.Roles.All(r => r.Name != homeOwnerRole.Name))
        {
            await _roleManager.CreateAsync(homeOwnerRole);
        }

        // Default users
        var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

        if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await _userManager.CreateAsync(administrator, "Administrator1!");
            await _userManager.AddToRolesAsync(administrator, new [] { administratorRole.Name });
        }

        // Default data
        if (!await _context.Rules.AnyAsync())
        {
            _context.Rules.AddRange(
                new Rule() { Name = "Smokers welcome" },
                new Rule() { Name = "Pets welcome" },
                new Rule() { Name = "Children welcome" },
                new Rule() { Name = "Dog to feed" },
                new Rule() { Name = "Cat to feed" },
                new Rule() { Name = "Plants to water" }
            );
        }

        if (!await _context.Amenities.AnyAsync())
        {
            _context.Amenities.AddRange(
                new Amenity() { Name = "TV" },
                new Amenity() { Name = "WiFi" },
                new Amenity() { Name = "Dishwasher" },
                new Amenity() { Name = "Dryer" },
                new Amenity() { Name = "Washing machine" },
                new Amenity() { Name = "Microwave oven" },
                new Amenity() { Name = "Freezer" },
                new Amenity() { Name = "Oven" },
                new Amenity() { Name = "Fridge" },
                new Amenity() { Name = "Bathtub" },
                new Amenity() { Name = "Heating system" },
                new Amenity() { Name = "Wheelchair accessible" },
                new Amenity() { Name = "Baby gear" },
                new Amenity() { Name = "Computer" },
                new Amenity() { Name = "Internet" },
                new Amenity() { Name = "Private garden" },
                new Amenity() { Name = "Private pool" },
                new Amenity() { Name = "BBQ" },
                new Amenity() { Name = "A/C" },
                new Amenity() { Name = "Fireplace" },
                new Amenity() { Name = "Elevator" },
                new Amenity() { Name = "Private parking space" },
                new Amenity() { Name = "Car" },
                new Amenity() { Name = "Bicycle" },
                new Amenity() { Name = "Motorcycle" },
                new Amenity() { Name = "Doorman included" },
                new Amenity() { Name = "Cleaning person included" },
                new Amenity() { Name = "Balcony" }
            );
        }

        if (!await _context.BedTypes.AnyAsync())
        {
            _context.BedTypes.AddRange(
                new BedType() { Name = "Single beds" },
                new BedType() { Name = "Double beds" },
                new BedType() { Name = "Children's beds" },
                new BedType() { Name = "Baby cribs" },
                new BedType() { Name = "Single put-up beds" },
                new BedType() { Name = "Double put-up beds" },
                new BedType() { Name = "Children's put-up" },
                new BedType() { Name = "Children's put-up beds" },
                new BedType() { Name = "Portable cribs" },
                new BedType() { Name = "Portable cribs" }
            );
        }

        if (!await _context.BedTypes.AnyAsync())
        {
            _context.Languages.AddRange(
                new Language() { Name = "Français" },
                new Language() { Name = "English" },
                new Language() { Name = "Español" },
                new Language() { Name = "Italiano" },
                new Language() { Name = "Português" },
                new Language() { Name = "Nederlands" },
                new Language() { Name = "عربي" },
                new Language() { Name = "中文" },
                new Language() { Name = "日本語" },
                new Language() { Name = "한국어" },
                new Language() { Name = "Türkçe" },
                new Language() { Name = "Eλληνικά" },
                new Language() { Name = "Українська" },
                new Language() { Name = "Deutsch" },
                new Language() { Name = "Dansk" },
                new Language() { Name = "hrvatski" },
                new Language() { Name = "Norsk" },
                new Language() { Name = "Svenska" }
            );
        }
            
        
        await _context.SaveChangesAsync();
    }
}
