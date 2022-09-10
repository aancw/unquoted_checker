# unquoted_checker
Scanner for finding Unquoted Service Path for Privilege Escalation

# Purpose

This tool is able to find the Unquoted Service Path for doing Privilege Escalation when using `execute-assembly` or run directly on compromised machine.

# Usage

- Using execute assembly

```
execute-assembly path\to\unquoted_checker.exe
Checking Unquoted Service Path for Privilege Escalation...
    Service name:    VulnService
    Path:            C:\Program Files\Vuln Service\Vuln.exe
    Started:         False
    State:           Stopped
    Status:          OK
Press any key to continue . . .
```

- Direct run

```
C:\User> unquoted_checker.exe
Checking Unquoted Service Path for Privilege Escalation...
    Service name:    VulnService
    Path:            C:\Program Files\Vuln Service\Vuln.exe
    Started:         False
    State:           Stopped
    Status:          OK
Press any key to continue . . .
```


# License 

MIT License