@echo off
@REM //------------------------------------------------------------------------------
@REM 03/08/2009
@REM //------------------------------------------------------------------------------
@REM Nettoyage des repertoires bin et obj de la solution  
@REM //------------------------------------------------------------------------------


rd /S /Q MasterClasses\bin
rd /S /Q MasterClasses\obj

rd /S /Q MasterContactsTests\bin
rd /S /Q MasterContactsTests\obj

rd /S /Q MasterContacts\bin
rd /S /Q MasterContacts\obj

rd /S /Q MasterContactsDonnees\bin
rd /S /Q MasterContactsDonnees\obj
rd /S /Q MasterContactsMetier\bin
rd /S /Q MasterContactsMetier\obj

rd /S /Q TestResults

echo on
