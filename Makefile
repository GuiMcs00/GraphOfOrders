TEST_NAME = 
SOLUTION_NAME = GraphOfOrders

setup:
	dotnet new sln --name $(SOLUTION_NAME)

	# Set up the Class Library
	dotnet new classlib --framework "netstandard2.0" --output $(SOLUTION_NAME).Lib
	dotnet sln $(SOLUTION_NAME).sln add $(SOLUTION_NAME).Lib/$(SOLUTION_NAME).Lib.csproj
	
	# Set up the Repository Project
	dotnet new classlib --framework "net7.0" --output $(SOLUTION_NAME).Repo
	dotnet sln $(SOLUTION_NAME).sln add $(SOLUTION_NAME).Repo/$(SOLUTION_NAME).Repo.csproj
	dotnet add $(SOLUTION_NAME).Repo/$(SOLUTION_NAME).Repo.csproj reference $(SOLUTION_NAME).Lib/$(SOLUTION_NAME).Lib.csproj
	
	# Set up the Service Project
	dotnet new classlib --framework "net7.0" --output $(SOLUTION_NAME).Service
	dotnet sln $(SOLUTION_NAME).sln add $(SOLUTION_NAME).Service/$(SOLUTION_NAME).Service.csproj
	dotnet add $(SOLUTION_NAME).Service/$(SOLUTION_NAME).Service.csproj reference $(SOLUTION_NAME).Lib/$(SOLUTION_NAME).Lib.csproj
	dotnet add $(SOLUTION_NAME).Service/$(SOLUTION_NAME).Service.csproj reference $(SOLUTION_NAME).Repo/$(SOLUTION_NAME).Repo.csproj
	
	# Set up the API Project
	dotnet new webapi --framework "net7.0" --output $(SOLUTION_NAME).Api
	dotnet sln $(SOLUTION_NAME).sln add $(SOLUTION_NAME).Api/$(SOLUTION_NAME).Api.csproj
	dotnet add $(SOLUTION_NAME).Api/$(SOLUTION_NAME).Api.csproj reference $(SOLUTION_NAME).Service/$(SOLUTION_NAME).Service.csproj
	
	# Set up the Test Project
	dotnet new xunit --framework "net7.0" --output $(SOLUTION_NAME).Test
	dotnet sln $(SOLUTION_NAME).sln add $(SOLUTION_NAME).Test/$(SOLUTION_NAME).Test.csproj
	dotnet add $(SOLUTION_NAME).Test/$(SOLUTION_NAME).Test.csproj reference $(SOLUTION_NAME).Lib/$(SOLUTION_NAME).Lib.csproj
	dotnet add $(SOLUTION_NAME).Test/$(SOLUTION_NAME).Test.csproj reference $(SOLUTION_NAME).Repo/$(SOLUTION_NAME).Repo.csproj
	dotnet add $(SOLUTION_NAME).Test/$(SOLUTION_NAME).Test.csproj reference $(SOLUTION_NAME).Service/$(SOLUTION_NAME).Service.csproj
	

build:
	dotnet build $(SOLUTION_NAME).sln

test:
	@if [ -z "$(TEST_NAME)" ]; then \
		dotnet test $(SOLUTION_NAME).Test/$(SOLUTION_NAME).Test.csproj; \
	else \
		dotnet test $(SOLUTION_NAME).Test/$(SOLUTION_NAME).Test.csproj --filter "FullyQualifiedName~$(SOLUTION_NAME).Test.$(TEST_NAME)"; \
	fi

clean:
	dotnet clean $(SOLUTION_NAME).sln

restore:
	dotnet restore $(SOLUTION_NAME).sln

rebuild: clean restore build

webapi:
	dotnet new webapi --framework "net7" 

.PHONY: build test clean restore rebuild
