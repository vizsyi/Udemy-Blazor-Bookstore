SELECT IS_SRVROLEMEMBER('sysadmin');

-- Az aktuális login neve
SELECT SUSER_SNAME();

-- vagy
SELECT ORIGINAL_LOGIN();

-- vagy
SELECT SYSTEM_USER;
-- LAPTOP-SONICMAS\Pisti

-- Ha a session-öd contextben van (impersonálva van), akkor ez adja az aktuális usert
SELECT CURRENT_USER;

SELECT IS_SRVROLEMEMBER('sysadmin');

CREATE LOGIN [LAPTOP-SONICMAS\Pisti] FROM WINDOWS;