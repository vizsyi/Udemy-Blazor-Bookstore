SELECT IS_SRVROLEMEMBER('sysadmin');

-- Az aktu�lis login neve
SELECT SUSER_SNAME();

-- vagy
SELECT ORIGINAL_LOGIN();

-- vagy
SELECT SYSTEM_USER;
-- LAPTOP-SONICMAS\Pisti

-- Ha a session-�d contextben van (imperson�lva van), akkor ez adja az aktu�lis usert
SELECT CURRENT_USER;

SELECT IS_SRVROLEMEMBER('sysadmin');

CREATE LOGIN [LAPTOP-SONICMAS\Pisti] FROM WINDOWS;