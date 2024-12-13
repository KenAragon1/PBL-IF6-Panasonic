using System.ComponentModel.DataAnnotations;
using panasonic.Models;

namespace panasonic.ViewModels.MaterialInventoryViewModel;


public class MaterialTableData
{
    public required List<MaterialInventory> MaterialInventories { get; set; }
}


public class PreperationRoomViewModel : MaterialTableData
{

}


public class SendViewModel
{
    public List<MaterialRequest> MaterialRequests { get; set; } = [];

    public List<SendForm> Forms { get; set; } = [];
}

public class SendForm
{
    [Required]
    public int MaterialRequestId { get; set; }

    [Required]
    public int QuantitySend { get; set; }

    [Required]
    public string Measurement { get; set; } = string.Empty;
}


public class PickupViewModel
{
    [Required]
    public int ProductionLineDestination { get; set; }

    [Required]
    public List<MaterialInventoryForm> Forms { get; set; } = new List<MaterialInventoryForm> { new MaterialInventoryForm() };

    public List<ProductionLine>? ProductionLineOptions { get; set; }
    public List<MaterialInventory>? MaterialInventoryOptions { get; set; }
}

public class ReturnViewModel
{
    public List<MaterialInventoryForm> Forms { get; set; } = new List<MaterialInventoryForm> { new MaterialInventoryForm() };

    public List<MaterialInventory> MaterialInventories { get; set; } = new List<MaterialInventory>();
    public List<ProductionLine> ProductionLines { get; set; } = new List<ProductionLine>();
}

public class MaterialInventoryForm
{
    [Required]
    public int MaterialInventoryId { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
    public int Quantity { get; set; }
}


