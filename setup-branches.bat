@echo off

git checkout main

for %%B in (productservice orderservice docker-setup authentication) do (
    git checkout -b feature/%%B
    git push -u origin feature/%%B
    git checkout main
)


