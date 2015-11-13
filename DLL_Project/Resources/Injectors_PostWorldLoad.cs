using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using Verse;

namespace CommunityCoreLibrary
{

    public static partial class Resources
    {

        public static partial class Injectors
        {

            public static class PostWorldLoad
            {
                
            	public static bool			ThingsToInject()
            	{
            		return Controller.Data.ModHelperDefs.Any();
            	}
            	
                public static bool          Inject()
                {
                    var ModHelperDefs = Controller.Data.ModHelperDefs;
                    foreach( var ModHelperDef in ModHelperDefs )
                    {
                        if( !ModHelperDef.PostWorldLoadersInjected )
                        {
                            // TODO:  Alpha 13 API change
                            //if( ModHelperDef.InjectPostWorldLoaders() )

                            ModHelperDef.InjectPostWorldLoaders();
                            if( ModHelperDef.PostWorldLoadersInjected )
                            {
                                CCL_Log.Message( "Injected Post World Loaders", ModHelperDef.ModName );
                            }
                            else
                            {
                                CCL_Log.Error( "Error in Post Load Injections", ModHelperDef.ModName );
                                return false;
                            }
                        }
                    }
                    return true;
                }

            }

        }

    }

}
