public static NXOpen.Body CreateExtrude(Curve[] curves, double startValue,  double endValue)
{
    NXOpen.Part workPart = NXOpen.Session.GetSession().Parts.Work;
    
    /**
     * 拉伸构建器
     */
    NXOpen.Features.Feature nullNXOpenFeaturesFeature = null;
    NXOpen.Features.ExtrudeBuilder extrudeBuilder = 
        workPart.Features.CreateExtrudeBuilder(nullNXOpenFeaturesFeature);

    NXOpen.Section section = null;
    extrudeBuilder.Section = section;
    extrudeBuilder.AllowSelfIntersectingSection(true);


    /**
     * 表区域驱动——选择曲线
     */

    extrudeBuilder.FeatureOptions.BodyType = NXOpen.GeometricUtilities.FeatureOptions.BodyStyle.Solid;

    /**
     * 限制
     */
    #region 开始——值
    extrudeBuilder.Limits.StartExtend.TrimType = NXOpen.GeometricUtilities.Extend.ExtendType.Value; 
    extrudeBuilder.Limits.StartExtend.TrimType = NXOpen.GeometricUtilities.Extend.ExtendType.Symmetric; 
    extrudeBuilder.Limits.StartExtend.TrimType = NXOpen.GeometricUtilities.Extend.ExtendType.UntilNext; 
    extrudeBuilder.Limits.StartExtend.TrimType = NXOpen.GeometricUtilities.Extend.ExtendType.UntilSelected; 
    extrudeBuilder.Limits.StartExtend.TrimType = NXOpen.GeometricUtilities.Extend.ExtendType.UntilExtended; 
    extrudeBuilder.Limits.StartExtend.TrimType = NXOpen.GeometricUtilities.Extend.ExtendType.ThroughAll; 
    #endregion

    /**
     * 布尔
     */
    #region 布尔——无
    extrudeBuilder.BooleanOperation.Type = NXOpen.GeometricUtilities.BooleanOperation.BooleanType.Create;
    #endregion
    #region 布尔——合并
    extrudeBuilder.BooleanOperation.Type = NXOpen.GeometricUtilities.BooleanOperation.BooleanType.Unite;
    extrudeBuilder.BooleanOperation.SetTargetBodies(new NXOpen.Body[0]);
    #endregion
    #region 布尔——减去
    extrudeBuilder.BooleanOperation.Type = NXOpen.GeometricUtilities.BooleanOperation.BooleanType.Subtract;
    extrudeBuilder.BooleanOperation.SetTargetBodies(new NXOpen.Body[0]);
    #endregion
    #region 布尔——相交
    extrudeBuilder.BooleanOperation.Type = NXOpen.GeometricUtilities.BooleanOperation.BooleanType.Intersect;
    extrudeBuilder.BooleanOperation.SetTargetBodies(new NXOpen.Body[0]);
    #endregion
    #region 布尔——缝合——未见使用
    extrudeBuilder.BooleanOperation.Type = NXOpen.GeometricUtilities.BooleanOperation.BooleanType.Sew;
    #endregion
    #region 布尔——自动判断
    #endregion

    /**
     * 偏置
     */
    #region 偏置——无
    //偏置
    extrudeBuilder.Offset.Option = NXOpen.GeometricUtilities.Type.NoOffset;
    #endregion
    #region 偏置——单侧
    //偏置
    extrudeBuilder.Offset.Option = NXOpen.GeometricUtilities.Type.SingleOffset;
    //结束
    extrudeBuilder.Offset.EndOffset.RightHandSide = "666";
    #endregion
    #region 偏置——两侧
    //偏置
    extrudeBuilder.Offset.Option = NXOpen.GeometricUtilities.Type.NonsymmetricOffset;
    //开始
    extrudeBuilder.Offset.StartOffset.RightHandSide = "999";
    //结束
    extrudeBuilder.Offset.EndOffset.RightHandSide = "666";
    #endregion
    #region 偏置——对称
    //偏置
    extrudeBuilder.Offset.Option = NXOpen.GeometricUtilities.Type.SymmetricOffset;
    //开始
    extrudeBuilder.Offset.StartOffset.RightHandSide = "999";
    //结束
    extrudeBuilder.Offset.EndOffset.RightHandSide = "666";
    #endregion

    throw new NotImplementedException();
}
