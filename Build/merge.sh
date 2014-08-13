#!/usr/bin/env sh

# Download: https://github.com/yck1509/ConfuserEx/releases

# mono ../../proj.mono/tools/monomerge.exe -out Tracker.Core.dll \
#   ../../proj.wp/TrackerExample/bin/Release/Smartlead.Tracker.Core.dll \
#   ../../proj.wp/TrackerExample/bin/Release/JsonLight.dll \
#   ../../proj.wp/TrackerExample/bin/Release/MD5.dll

# mono ../../proj.mono/tools/monomerge.exe -out Tracker.WP.dll \
#   ../../proj.wp/TrackerExample/bin/Release/SmartTracker.dll \
#   ../../proj.wp/TrackerExample/bin/Release/ODINWP.dll 

# cp ../../proj.wp/TrackerExample/bin/Release/Actionpay.Tracker.Core.dll Actionpay.Tracker.Core.dll
cp ../../proj.wp/TrackerExample/bin/Release/JsonLight.dll JsonLight.dll
cp ../../proj.wp/TrackerExample/bin/Release/MD5.dll MD5.dll
cp ../../proj.wp/TrackerExample/bin/Release/SmartTracker.dll SmartTracker.dll
cp ../../proj.wp/TrackerExample/bin/Release/ODINWP.dll ODINWP.dll
