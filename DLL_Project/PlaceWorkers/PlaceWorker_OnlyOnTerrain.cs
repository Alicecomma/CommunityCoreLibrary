﻿using Verse;

namespace CommunityCoreLibrary
{

    public class PlaceWorker_OnlyOnTerrain : PlaceWorker
    {
        
        public override AcceptanceReport    AllowsPlacing( BuildableDef checkingDef, IntVec3 loc, Rot4 rot )
        {
            var thingDef = checkingDef as ThingDef;
#if DEBUG
            if( thingDef == null )
            {
                Log.Error( "Community Core Library :: Restricted PlaceWorker :: OnlyOnTerrain - Unable to cast BuildableDef to ThingDef!" );
                return AcceptanceReport.WasRejected;
            }
#endif

            var Restrictions = thingDef.RestrictedPlacement_Properties();
#if DEBUG
            if( Restrictions == null )
            {
                Log.Error( "Community Core Library :: Restricted PlaceWorker :: OnlyOnTerrain - Unable to get properties!" );
                return AcceptanceReport.WasRejected;
            }
#endif

            TerrainDef terrainDef = loc.GetTerrain();
            for( int i = 0; i < Restrictions.RestrictedTerrain.Count; i++ )
            {
                if( Restrictions.RestrictedTerrain[ i ] == terrainDef )
                {
                    return AcceptanceReport.WasAccepted;
                }
            }

            return (AcceptanceReport)"MessagePlacementNotOn".Translate() + terrainDef.label;
        }

    }

}
