{
  description = "Lian .NET development environment";

  inputs = {
    nixpkgs.url = "github:nixos/nixpkgs?ref=nixos-unstable";
  };

  outputs = { nixpkgs, ... }: let
    system = "x86_64-linux";
  in {
    devShells.${system}.default = let
      pkgs = import nixpkgs { inherit system; };
    in pkgs.mkShell {
      packages = with pkgs; [
        dotnet-sdk_9
        dotnet-ef
        omnisharp-roslyn
        nodejs
      ];
    };
  };
}
