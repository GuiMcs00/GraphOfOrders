using Xunit;
using GraphOfOrders.Lib.Entities;
using GraphOfOrders.Lib.Enums;

namespace GraphOfOrders.Test.Domains.ActionTypes;

public class ProcessActionTypesTest
{
    [Fact]
    public void SetActionType_ShouldStoreCorrectTaxActionType()
    {
        // Arrange
        var processActionType = new ProcessActionType();
        var expectedActionTypeName = TaxProcessTypes.ApuracaoDeImpostos.ToString();

        // Act
        processActionType.SetActionType(TaxProcessTypes.ApuracaoDeImpostos);

        // Assert
        Assert.Equal(expectedActionTypeName, processActionType.ActionTypeName);
    }

    [Fact]
    public void GetActionType_ShouldReturnCorrectTaxActionType()
    {
        // Arrange
        var processActionType = new ProcessActionType();
        processActionType.SetActionType(TaxProcessTypes.EmissaoDeDeclaracoes);

        // Act
        var actionType = processActionType.GetActionType<TaxProcessTypes>();

        // Assert
        Assert.Equal(TaxProcessTypes.EmissaoDeDeclaracoes, actionType);
    }
    
    [Fact]
    public void SetActionType_ShouldStoreCorrectPeopleActionType()
    {
        // Arrange
        var processActionType = new ProcessActionType();
        var expectedActionTypeName = PeopleProcessTypes.GestaoDeFerias.ToString();

        // Act
        processActionType.SetActionType(PeopleProcessTypes.GestaoDeFerias);

        // Assert
        Assert.Equal(expectedActionTypeName, processActionType.ActionTypeName);
    }

    [Fact]
    public void GetActionType_ShouldReturnCorrectPeopleActionType()
    {
        // Arrange
        var processActionType = new ProcessActionType();
        processActionType.SetActionType(PeopleProcessTypes.GestaoDeFerias);

        // Act
        var actionType = processActionType.GetActionType<PeopleProcessTypes>();

        // Assert
        Assert.Equal(PeopleProcessTypes.GestaoDeFerias, actionType);
    }
    
    
    [Fact]
    public void GetActionType_WithIncorrectEnum_ShouldThrowException()
    {
        // Arrange
        var processActionType = new ProcessActionType();
        processActionType.SetActionType(TaxProcessTypes.ApuracaoDeImpostos);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => processActionType.GetActionType<PeopleProcessTypes>());
    }
}