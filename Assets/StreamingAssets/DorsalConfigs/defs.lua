--- DO NOT EDIT THIS FILE
--- Generated by DorsalVR 2.0.5
--- This file, and workspace.code-workspace, are required to make Visual Studio Code's IntelliSense work for DorsalVR's Lua scripting.
--- See: https://github.com/MichaelJW/DorsalVR

--- @class DolphinManager
--- This manages Dolphin.
local DolphinManager_def = {}
--- @param dolphinConfig DolphinConfig
--- Launches a new instance of Dolphin.
function DolphinManager_def:Launch(dolphinConfig) end
--- @return DolphinConfig
function DolphinManager_def:CreateDolphinConfig() end

--- @class DolphinConfig
--- @field configDir string
--- @field outputGameTo table<number, string>
--- @field exec string
--- @field videoBackend string
--- @field audioEmulation string
--- @field movie string
--- @field user string
--- @field nandTitle string
--- @field saveState string
--- @field extension string
--- @field exePath string
local DolphinConfig_def = {}
--- @return DolphinConfig
function DolphinConfig_def:Clone() end
--- @return string
function DolphinConfig_def:ToString() end
--- @param systemSectionKey string
--- @param value string
--- Sets a configuration option as specified by a --config or -C command line option
function DolphinConfig_def:SetConfigOption(systemSectionKey, value) end
--- @param systemSectionKey string
--- Clears a configuration option as specified by a --config or -C command line option
function DolphinConfig_def:ClearConfigOption(systemSectionKey) end
--- Clears all configuration options specified by a --config or -C command line option
function DolphinConfig_def:ClearAllConfigOptions() end

--- Define the objects that are always created by DorsalVR and therefore already accessible:
--- @type DolphinManager
dolphinManager = {}
