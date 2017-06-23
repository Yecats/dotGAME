<root dataType="Struct" type="Duality.Resources.Scene" id="129723834">
  <assetInfo />
  <globalGravity dataType="Struct" type="Duality.Vector2" />
  <serializeObj dataType="Array" type="Duality.GameObject[]" id="427169525">
    <item dataType="Struct" type="Duality.GameObject" id="837467146">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="1137773140">
        <_items dataType="Array" type="Duality.Component[]" id="4135050468">
          <item dataType="Struct" type="Duality.Components.Transform" id="3197782078">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <angleVel dataType="Float">0</angleVel>
            <angleVelAbs dataType="Float">0</angleVelAbs>
            <deriveAngle dataType="Bool">true</deriveAngle>
            <gameobj dataType="ObjectRef">837467146</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <parentTransform />
            <pos dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
              <Z dataType="Float">-500</Z>
            </pos>
            <posAbs dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
              <Z dataType="Float">-500</Z>
            </posAbs>
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
            <vel dataType="Struct" type="Duality.Vector3" />
            <velAbs dataType="Struct" type="Duality.Vector3" />
          </item>
          <item dataType="Struct" type="Duality.Components.Camera" id="1374742953">
            <active dataType="Bool">true</active>
            <farZ dataType="Float">10000</farZ>
            <focusDist dataType="Float">500</focusDist>
            <gameobj dataType="ObjectRef">837467146</gameobj>
            <nearZ dataType="Float">0</nearZ>
            <passes dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Components.Camera+Pass]]" id="2749626421">
              <_items dataType="Array" type="Duality.Components.Camera+Pass[]" id="946934262" length="4">
                <item dataType="Struct" type="Duality.Components.Camera+Pass" id="3430645472">
                  <clearColor dataType="Struct" type="Duality.Drawing.ColorRgba" />
                  <clearDepth dataType="Float">1</clearDepth>
                  <clearFlags dataType="Enum" type="Duality.Drawing.ClearFlag" name="All" value="3" />
                  <input />
                  <matrixMode dataType="Enum" type="Duality.Drawing.RenderMatrix" name="PerspectiveWorld" value="0" />
                  <output dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.RenderTarget]]" />
                  <visibilityMask dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="AllGroups" value="2147483647" />
                </item>
                <item dataType="Struct" type="Duality.Components.Camera+Pass" id="3643043726">
                  <clearColor dataType="Struct" type="Duality.Drawing.ColorRgba" />
                  <clearDepth dataType="Float">1</clearDepth>
                  <clearFlags dataType="Enum" type="Duality.Drawing.ClearFlag" name="None" value="0" />
                  <input />
                  <matrixMode dataType="Enum" type="Duality.Drawing.RenderMatrix" name="OrthoScreen" value="1" />
                  <output dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.RenderTarget]]" />
                  <visibilityMask dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="All" value="4294967295" />
                </item>
              </_items>
              <_size dataType="Int">2</_size>
            </passes>
            <perspective dataType="Enum" type="Duality.Drawing.PerspectiveMode" name="Parallax" value="1" />
            <visibilityMask dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="All" value="4294967295" />
          </item>
          <item dataType="Struct" type="Duality.Components.SoundListener" id="1490948517">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">837467146</gameobj>
          </item>
          <item dataType="Struct" type="DotGame.CameraController" id="3077612490">
            <active dataType="Bool">true</active>
            <followTarget dataType="Struct" type="Duality.Components.Transform" id="3866096440">
              <active dataType="Bool">true</active>
              <angle dataType="Float">0</angle>
              <angleAbs dataType="Float">0</angleAbs>
              <angleVel dataType="Float">0</angleVel>
              <angleVelAbs dataType="Float">0</angleVelAbs>
              <deriveAngle dataType="Bool">true</deriveAngle>
              <gameobj dataType="Struct" type="Duality.GameObject" id="1505781508">
                <active dataType="Bool">true</active>
                <children />
                <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="3316133070">
                  <_items dataType="Array" type="Duality.Component[]" id="4051562448">
                    <item dataType="ObjectRef">3866096440</item>
                    <item dataType="Struct" type="Duality.Components.Physics.RigidBody" id="273590736">
                      <active dataType="Bool">true</active>
                      <allowParent dataType="Bool">false</allowParent>
                      <angularDamp dataType="Float">0.3</angularDamp>
                      <angularVel dataType="Float">0</angularVel>
                      <bodyType dataType="Enum" type="Duality.Components.Physics.BodyType" name="Dynamic" value="1" />
                      <colCat dataType="Enum" type="Duality.Components.Physics.CollisionCategory" name="Cat1" value="1" />
                      <colFilter />
                      <colWith dataType="Enum" type="Duality.Components.Physics.CollisionCategory" name="All" value="2147483647" />
                      <continous dataType="Bool">false</continous>
                      <explicitInertia dataType="Float">0</explicitInertia>
                      <explicitMass dataType="Float">0</explicitMass>
                      <fixedAngle dataType="Bool">false</fixedAngle>
                      <gameobj dataType="ObjectRef">1505781508</gameobj>
                      <ignoreGravity dataType="Bool">false</ignoreGravity>
                      <joints />
                      <linearDamp dataType="Float">0.3</linearDamp>
                      <linearVel dataType="Struct" type="Duality.Vector2" />
                      <revolutions dataType="Float">0</revolutions>
                      <shapes dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Components.Physics.ShapeInfo]]" id="2519424736">
                        <_items dataType="Array" type="Duality.Components.Physics.ShapeInfo[]" id="3842701276" length="4">
                          <item dataType="Struct" type="Duality.Components.Physics.PolyShapeInfo" id="2771237572">
                            <convexPolygons dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Vector2[]]]" id="1308450628">
                              <_items dataType="Array" type="Duality.Vector2[][]" id="543505988" length="4">
                                <item dataType="Array" type="Duality.Vector2[]" id="3466459716">
                                  <item dataType="Struct" type="Duality.Vector2">
                                    <X dataType="Float">-47.7723923</X>
                                    <Y dataType="Float">25.3670158</Y>
                                  </item>
                                  <item dataType="Struct" type="Duality.Vector2">
                                    <X dataType="Float">-0.6197815</X>
                                    <Y dataType="Float">-33.80488</Y>
                                  </item>
                                  <item dataType="Struct" type="Duality.Vector2">
                                    <X dataType="Float">46.90264</X>
                                    <Y dataType="Float">25.3670158</Y>
                                  </item>
                                </item>
                              </_items>
                              <_size dataType="Int">1</_size>
                            </convexPolygons>
                            <density dataType="Float">1</density>
                            <friction dataType="Float">0.3</friction>
                            <parent dataType="ObjectRef">273590736</parent>
                            <restitution dataType="Float">0.3</restitution>
                            <sensor dataType="Bool">false</sensor>
                            <userTag dataType="Int">0</userTag>
                            <vertices dataType="Array" type="Duality.Vector2[]" id="2164108950">
                              <item dataType="Struct" type="Duality.Vector2">
                                <X dataType="Float">-47.7723923</X>
                                <Y dataType="Float">25.3670158</Y>
                              </item>
                              <item dataType="Struct" type="Duality.Vector2">
                                <X dataType="Float">-0.6197815</X>
                                <Y dataType="Float">-33.80488</Y>
                              </item>
                              <item dataType="Struct" type="Duality.Vector2">
                                <X dataType="Float">46.90264</X>
                                <Y dataType="Float">25.3670158</Y>
                              </item>
                            </vertices>
                          </item>
                        </_items>
                        <_size dataType="Int">1</_size>
                      </shapes>
                    </item>
                    <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="3147948076">
                      <active dataType="Bool">true</active>
                      <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
                        <A dataType="Byte">255</A>
                        <B dataType="Byte">255</B>
                        <G dataType="Byte">255</G>
                        <R dataType="Byte">255</R>
                      </colorTint>
                      <customMat />
                      <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
                      <gameobj dataType="ObjectRef">1505781508</gameobj>
                      <offset dataType="Int">0</offset>
                      <pixelGrid dataType="Bool">false</pixelGrid>
                      <rect dataType="Struct" type="Duality.Rect">
                        <H dataType="Float">75</H>
                        <W dataType="Float">98</W>
                        <X dataType="Float">-49</X>
                        <Y dataType="Float">-37.5</Y>
                      </rect>
                      <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
                      <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
                        <contentPath dataType="String">Data\PlayerShip.Material.res</contentPath>
                      </sharedMat>
                      <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group0" value="1" />
                    </item>
                    <item dataType="Struct" type="DotGame.PlayerShip" id="3779886832">
                      <active dataType="Bool">true</active>
                      <gameobj dataType="ObjectRef">1505781508</gameobj>
                      <laserPrefab dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Prefab]]">
                        <contentPath dataType="String">Data\Laser.Prefab.res</contentPath>
                      </laserPrefab>
                      <moveAcceleration dataType="Float">0.2</moveAcceleration>
                      <turnSpeed dataType="Float">0.09839355</turnSpeed>
                    </item>
                  </_items>
                  <_size dataType="Int">4</_size>
                </compList>
                <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="3657965386" surrogate="true">
                  <header />
                  <body>
                    <keys dataType="Array" type="System.Object[]" id="3422822796">
                      <item dataType="Type" id="3471896484" value="Duality.Components.Transform" />
                      <item dataType="Type" id="747347734" value="Duality.Components.Renderers.SpriteRenderer" />
                      <item dataType="Type" id="1441205920" value="Duality.Components.Physics.RigidBody" />
                      <item dataType="Type" id="2666272866" value="DotGame.PlayerShip" />
                    </keys>
                    <values dataType="Array" type="System.Object[]" id="1086572022">
                      <item dataType="ObjectRef">3866096440</item>
                      <item dataType="ObjectRef">3147948076</item>
                      <item dataType="ObjectRef">273590736</item>
                      <item dataType="ObjectRef">3779886832</item>
                    </values>
                  </body>
                </compMap>
                <compTransform dataType="ObjectRef">3866096440</compTransform>
                <identifier dataType="Struct" type="System.Guid" surrogate="true">
                  <header>
                    <data dataType="Array" type="System.Byte[]" id="3391507224">uSmromuVHU6TY25bMNRVoA==</data>
                  </header>
                  <body />
                </identifier>
                <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
                <name dataType="String">PlayerShip</name>
                <parent />
                <prefabLink />
              </gameobj>
              <ignoreParent dataType="Bool">false</ignoreParent>
              <parentTransform />
              <pos dataType="Struct" type="Duality.Vector3">
                <X dataType="Float">1</X>
                <Y dataType="Float">2</Y>
                <Z dataType="Float">0</Z>
              </pos>
              <posAbs dataType="Struct" type="Duality.Vector3">
                <X dataType="Float">1</X>
                <Y dataType="Float">2</Y>
                <Z dataType="Float">0</Z>
              </posAbs>
              <scale dataType="Float">1</scale>
              <scaleAbs dataType="Float">1</scaleAbs>
              <vel dataType="Struct" type="Duality.Vector3" />
              <velAbs dataType="Struct" type="Duality.Vector3" />
            </followTarget>
            <gameobj dataType="ObjectRef">837467146</gameobj>
            <smoothness dataType="Float">5</smoothness>
          </item>
        </_items>
        <_size dataType="Int">4</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="3885245366" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="2009006590">
            <item dataType="ObjectRef">3471896484</item>
            <item dataType="Type" id="389988752" value="Duality.Components.Camera" />
            <item dataType="Type" id="2204398" value="Duality.Components.SoundListener" />
            <item dataType="Type" id="3723699308" value="DotGame.CameraController" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="2240946058">
            <item dataType="ObjectRef">3197782078</item>
            <item dataType="ObjectRef">1374742953</item>
            <item dataType="ObjectRef">1490948517</item>
            <item dataType="ObjectRef">3077612490</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">3197782078</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="649266062">6fwFH++A50CLl67am/rcBA==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">MainCamera</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="ObjectRef">1505781508</item>
    <item dataType="Struct" type="Duality.GameObject" id="2891765851">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="4070418985">
        <_items dataType="Array" type="Duality.Component[]" id="1240080910" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="957113487">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">2891765851</gameobj>
          </item>
          <item dataType="Struct" type="Duality.Components.Physics.RigidBody" id="1659575079">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">2891765851</gameobj>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="238965123">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">2891765851</gameobj>
          </item>
        </_items>
        <_size dataType="Int">3</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="2683124672" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="4188503971">
            <item dataType="ObjectRef">3471896484</item>
            <item dataType="ObjectRef">747347734</item>
            <item dataType="ObjectRef">1441205920</item>
          </keys>
          <values dataType="Array" type="System.Object[]" id="1644632952">
            <item dataType="ObjectRef">957113487</item>
            <item dataType="ObjectRef">238965123</item>
            <item dataType="ObjectRef">1659575079</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">957113487</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="2261005321">Mp1zNy+3kUWP4yzZAIQw+A==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">AsteroidBig</name>
      <parent />
      <prefabLink dataType="Struct" type="Duality.Resources.PrefabLink" id="723451403">
        <changes dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Resources.PrefabLink+VarMod]]" id="3699995828">
          <_items dataType="Array" type="Duality.Resources.PrefabLink+VarMod[]" id="2164809124" length="4">
            <item dataType="Struct" type="Duality.Resources.PrefabLink+VarMod">
              <childIndex dataType="Struct" type="System.Collections.Generic.List`1[[System.Int32]]" id="273388488">
                <_items dataType="Array" type="System.Int32[]" id="3342633580"></_items>
                <_size dataType="Int">0</_size>
              </childIndex>
              <componentType dataType="ObjectRef">3471896484</componentType>
              <prop dataType="MemberInfo" id="1804014302" value="P:Duality.Components.Transform:RelativePos" />
              <val dataType="Struct" type="Duality.Vector3">
                <X dataType="Float">197</X>
                <Y dataType="Float">-200.000015</Y>
                <Z dataType="Float">0</Z>
              </val>
            </item>
          </_items>
          <_size dataType="Int">1</_size>
        </changes>
        <obj dataType="ObjectRef">2891765851</obj>
        <prefab dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Prefab]]">
          <contentPath dataType="String">Data\AsteroidBig.Prefab.res</contentPath>
        </prefab>
      </prefabLink>
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="4118245743">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="3822922125">
        <_items dataType="Array" type="Duality.Component[]" id="88192294" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="2183593379">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <angleVel dataType="Float">0</angleVel>
            <angleVelAbs dataType="Float">0</angleVelAbs>
            <deriveAngle dataType="Bool">true</deriveAngle>
            <gameobj dataType="ObjectRef">4118245743</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <parentTransform />
            <pos dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
              <Z dataType="Float">5000</Z>
            </pos>
            <posAbs dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
              <Z dataType="Float">5000</Z>
            </posAbs>
            <scale dataType="Float">10</scale>
            <scaleAbs dataType="Float">10</scaleAbs>
            <vel dataType="Struct" type="Duality.Vector3" />
            <velAbs dataType="Struct" type="Duality.Vector3" />
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="1465445015">
            <active dataType="Bool">true</active>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">255</A>
              <B dataType="Byte">255</B>
              <G dataType="Byte">255</G>
              <R dataType="Byte">255</R>
            </colorTint>
            <customMat />
            <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
            <gameobj dataType="ObjectRef">4118245743</gameobj>
            <offset dataType="Int">0</offset>
            <pixelGrid dataType="Bool">false</pixelGrid>
            <rect dataType="Struct" type="Duality.Rect">
              <H dataType="Float">2000</H>
              <W dataType="Float">2000</W>
              <X dataType="Float">-1000</X>
              <Y dataType="Float">-1000</Y>
            </rect>
            <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="WrapBoth" value="3" />
            <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Data\SpaceBackground.Material.res</contentPath>
            </sharedMat>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group0" value="1" />
          </item>
        </_items>
        <_size dataType="Int">2</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="3820334008" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="2116825831">
            <item dataType="ObjectRef">3471896484</item>
            <item dataType="ObjectRef">747347734</item>
          </keys>
          <values dataType="Array" type="System.Object[]" id="2914336640">
            <item dataType="ObjectRef">2183593379</item>
            <item dataType="ObjectRef">1465445015</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">2183593379</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="3673118885">tT2y9sUOXUyF+A3bJAXbhw==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">SpaceBackground</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="1607918752">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="1420128550">
        <_items dataType="Array" type="Duality.Component[]" id="1165329664" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="3968233684">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">1607918752</gameobj>
          </item>
          <item dataType="Struct" type="Duality.Components.Physics.RigidBody" id="375727980">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">1607918752</gameobj>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="3250085320">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">1607918752</gameobj>
          </item>
        </_items>
        <_size dataType="Int">3</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="1455483578" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="3407493780">
            <item dataType="ObjectRef">3471896484</item>
            <item dataType="ObjectRef">747347734</item>
            <item dataType="ObjectRef">1441205920</item>
          </keys>
          <values dataType="Array" type="System.Object[]" id="4067870774">
            <item dataType="ObjectRef">3968233684</item>
            <item dataType="ObjectRef">3250085320</item>
            <item dataType="ObjectRef">375727980</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">3968233684</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="2234605360">EqkEgdLYNU2idgaQEZDfhw==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">AsteroidBig</name>
      <parent />
      <prefabLink dataType="Struct" type="Duality.Resources.PrefabLink" id="1092332070">
        <changes dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Resources.PrefabLink+VarMod]]" id="976598528">
          <_items dataType="Array" type="Duality.Resources.PrefabLink+VarMod[]" id="1365662876" length="4">
            <item dataType="Struct" type="Duality.Resources.PrefabLink+VarMod">
              <childIndex dataType="Struct" type="System.Collections.Generic.List`1[[System.Int32]]" id="2373180616">
                <_items dataType="Array" type="System.Int32[]" id="3599086188"></_items>
                <_size dataType="Int">0</_size>
              </childIndex>
              <componentType dataType="ObjectRef">3471896484</componentType>
              <prop dataType="ObjectRef">1804014302</prop>
              <val dataType="Struct" type="Duality.Vector3">
                <X dataType="Float">-329</X>
                <Y dataType="Float">-236</Y>
                <Z dataType="Float">0</Z>
              </val>
            </item>
          </_items>
          <_size dataType="Int">1</_size>
        </changes>
        <obj dataType="ObjectRef">1607918752</obj>
        <prefab dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Prefab]]">
          <contentPath dataType="String">Data\AsteroidBig.Prefab.res</contentPath>
        </prefab>
      </prefabLink>
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="3423528522">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="3484081428">
        <_items dataType="Array" type="Duality.Component[]" id="1581086820" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="1488876158">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">3423528522</gameobj>
          </item>
          <item dataType="Struct" type="Duality.Components.Physics.RigidBody" id="2191337750">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">3423528522</gameobj>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="770727794">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">3423528522</gameobj>
          </item>
        </_items>
        <_size dataType="Int">3</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="1939413302" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="3626710462">
            <item dataType="ObjectRef">3471896484</item>
            <item dataType="ObjectRef">747347734</item>
            <item dataType="ObjectRef">1441205920</item>
          </keys>
          <values dataType="Array" type="System.Object[]" id="1845871626">
            <item dataType="ObjectRef">1488876158</item>
            <item dataType="ObjectRef">770727794</item>
            <item dataType="ObjectRef">2191337750</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">1488876158</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="251680206">dKaT552s9ECjmYftfOxoyg==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">AsteroidBig</name>
      <parent />
      <prefabLink dataType="Struct" type="Duality.Resources.PrefabLink" id="1971548080">
        <changes dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Resources.PrefabLink+VarMod]]" id="234513864">
          <_items dataType="Array" type="Duality.Resources.PrefabLink+VarMod[]" id="4082206316" length="4">
            <item dataType="Struct" type="Duality.Resources.PrefabLink+VarMod">
              <childIndex dataType="Struct" type="System.Collections.Generic.List`1[[System.Int32]]" id="1510001064">
                <_items dataType="ObjectRef">3599086188</_items>
                <_size dataType="Int">0</_size>
              </childIndex>
              <componentType dataType="ObjectRef">3471896484</componentType>
              <prop dataType="ObjectRef">1804014302</prop>
              <val dataType="Struct" type="Duality.Vector3">
                <X dataType="Float">340</X>
                <Y dataType="Float">-95.00001</Y>
                <Z dataType="Float">0</Z>
              </val>
            </item>
          </_items>
          <_size dataType="Int">1</_size>
        </changes>
        <obj dataType="ObjectRef">3423528522</obj>
        <prefab dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Prefab]]">
          <contentPath dataType="String">Data\AsteroidBig.Prefab.res</contentPath>
        </prefab>
      </prefabLink>
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="2343344641">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="4005185027">
        <_items dataType="Array" type="Duality.Component[]" id="1776789798" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="408692277">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">2343344641</gameobj>
          </item>
          <item dataType="Struct" type="Duality.Components.Physics.RigidBody" id="1111153869">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">2343344641</gameobj>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="3985511209">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">2343344641</gameobj>
          </item>
        </_items>
        <_size dataType="Int">3</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="2665672632" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="3257872745">
            <item dataType="ObjectRef">3471896484</item>
            <item dataType="ObjectRef">747347734</item>
            <item dataType="ObjectRef">1441205920</item>
          </keys>
          <values dataType="Array" type="System.Object[]" id="3207871168">
            <item dataType="ObjectRef">408692277</item>
            <item dataType="ObjectRef">3985511209</item>
            <item dataType="ObjectRef">1111153869</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">408692277</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="3253029323">BNrFgGlPB0CKB0R2IipZAg==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">AsteroidBig</name>
      <parent />
      <prefabLink dataType="Struct" type="Duality.Resources.PrefabLink" id="4078281513">
        <changes dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Resources.PrefabLink+VarMod]]" id="3616368084">
          <_items dataType="Array" type="Duality.Resources.PrefabLink+VarMod[]" id="2614162660" length="4">
            <item dataType="Struct" type="Duality.Resources.PrefabLink+VarMod">
              <childIndex dataType="Struct" type="System.Collections.Generic.List`1[[System.Int32]]" id="1742244040">
                <_items dataType="ObjectRef">3599086188</_items>
                <_size dataType="Int">0</_size>
              </childIndex>
              <componentType dataType="ObjectRef">3471896484</componentType>
              <prop dataType="ObjectRef">1804014302</prop>
              <val dataType="Struct" type="Duality.Vector3">
                <X dataType="Float">241.33551</X>
                <Y dataType="Float">175.50853</Y>
                <Z dataType="Float">0</Z>
              </val>
            </item>
          </_items>
          <_size dataType="Int">1</_size>
        </changes>
        <obj dataType="ObjectRef">2343344641</obj>
        <prefab dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Prefab]]">
          <contentPath dataType="String">Data\AsteroidBig.Prefab.res</contentPath>
        </prefab>
      </prefabLink>
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="1758395620">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="1080984538">
        <_items dataType="Array" type="Duality.Component[]" id="2624903424" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="4118710552">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">1758395620</gameobj>
          </item>
          <item dataType="Struct" type="Duality.Components.Physics.RigidBody" id="526204848">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">1758395620</gameobj>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="3400562188">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">1758395620</gameobj>
          </item>
        </_items>
        <_size dataType="Int">3</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="131600058" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="3255892512">
            <item dataType="ObjectRef">3471896484</item>
            <item dataType="ObjectRef">747347734</item>
            <item dataType="ObjectRef">1441205920</item>
          </keys>
          <values dataType="Array" type="System.Object[]" id="2167806862">
            <item dataType="ObjectRef">4118710552</item>
            <item dataType="ObjectRef">3400562188</item>
            <item dataType="ObjectRef">526204848</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">4118710552</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="2443381052">mrxwRr5eOkCt4HC7wvbnRA==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">AsteroidBig</name>
      <parent />
      <prefabLink dataType="Struct" type="Duality.Resources.PrefabLink" id="160210138">
        <changes dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Resources.PrefabLink+VarMod]]" id="3268077056">
          <_items dataType="Array" type="Duality.Resources.PrefabLink+VarMod[]" id="2950069404" length="4">
            <item dataType="Struct" type="Duality.Resources.PrefabLink+VarMod">
              <childIndex dataType="Struct" type="System.Collections.Generic.List`1[[System.Int32]]" id="977935560">
                <_items dataType="ObjectRef">3599086188</_items>
                <_size dataType="Int">0</_size>
              </childIndex>
              <componentType dataType="ObjectRef">3471896484</componentType>
              <prop dataType="ObjectRef">1804014302</prop>
              <val dataType="Struct" type="Duality.Vector3">
                <X dataType="Float">-266.6645</X>
                <Y dataType="Float">153.50853</Y>
                <Z dataType="Float">0</Z>
              </val>
            </item>
          </_items>
          <_size dataType="Int">1</_size>
        </changes>
        <obj dataType="ObjectRef">1758395620</obj>
        <prefab dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Prefab]]">
          <contentPath dataType="String">Data\AsteroidBig.Prefab.res</contentPath>
        </prefab>
      </prefabLink>
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="1107159281">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="3975884179">
        <_items dataType="Array" type="Duality.Component[]" id="32582886" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="3467474213">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">1107159281</gameobj>
          </item>
          <item dataType="Struct" type="Duality.Components.Physics.RigidBody" id="4169935805">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">1107159281</gameobj>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="2749325849">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">1107159281</gameobj>
          </item>
        </_items>
        <_size dataType="Int">3</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="815803128" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="2599858169">
            <item dataType="ObjectRef">3471896484</item>
            <item dataType="ObjectRef">747347734</item>
            <item dataType="ObjectRef">1441205920</item>
          </keys>
          <values dataType="Array" type="System.Object[]" id="565010560">
            <item dataType="ObjectRef">3467474213</item>
            <item dataType="ObjectRef">2749325849</item>
            <item dataType="ObjectRef">4169935805</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">3467474213</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="1950387707">8aJLs7YFMkq0nffcCQvOMg==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">AsteroidBig</name>
      <parent />
      <prefabLink dataType="Struct" type="Duality.Resources.PrefabLink" id="627950201">
        <changes dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Resources.PrefabLink+VarMod]]" id="1642567508">
          <_items dataType="Array" type="Duality.Resources.PrefabLink+VarMod[]" id="3657671396" length="4">
            <item dataType="Struct" type="Duality.Resources.PrefabLink+VarMod">
              <childIndex dataType="Struct" type="System.Collections.Generic.List`1[[System.Int32]]" id="3610482888">
                <_items dataType="ObjectRef">3599086188</_items>
                <_size dataType="Int">0</_size>
              </childIndex>
              <componentType dataType="ObjectRef">3471896484</componentType>
              <prop dataType="ObjectRef">1804014302</prop>
              <val dataType="Struct" type="Duality.Vector3">
                <X dataType="Float">-6.664483</X>
                <Y dataType="Float">-421.4915</Y>
                <Z dataType="Float">0</Z>
              </val>
            </item>
          </_items>
          <_size dataType="Int">1</_size>
        </changes>
        <obj dataType="ObjectRef">1107159281</obj>
        <prefab dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Prefab]]">
          <contentPath dataType="String">Data\AsteroidBig.Prefab.res</contentPath>
        </prefab>
      </prefabLink>
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="1053859381">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="1029211463">
        <_items dataType="Array" type="Duality.Component[]" id="4194695886" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="3414174313">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">1053859381</gameobj>
          </item>
          <item dataType="Struct" type="Duality.Components.Physics.RigidBody" id="4116635905">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">1053859381</gameobj>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="2696025949">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">1053859381</gameobj>
          </item>
        </_items>
        <_size dataType="Int">3</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="1954479872" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="3972549357">
            <item dataType="ObjectRef">3471896484</item>
            <item dataType="ObjectRef">747347734</item>
            <item dataType="ObjectRef">1441205920</item>
          </keys>
          <values dataType="Array" type="System.Object[]" id="229310712">
            <item dataType="ObjectRef">3414174313</item>
            <item dataType="ObjectRef">2696025949</item>
            <item dataType="ObjectRef">4116635905</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">3414174313</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="3547780103">6tfG0xY28EmXbtty1vfCLw==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">AsteroidBig</name>
      <parent />
      <prefabLink dataType="Struct" type="Duality.Resources.PrefabLink" id="1294154949">
        <changes dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Resources.PrefabLink+VarMod]]" id="2086560532">
          <_items dataType="Array" type="Duality.Resources.PrefabLink+VarMod[]" id="4269707364" length="4">
            <item dataType="Struct" type="Duality.Resources.PrefabLink+VarMod">
              <childIndex dataType="Struct" type="System.Collections.Generic.List`1[[System.Int32]]" id="3754340040">
                <_items dataType="ObjectRef">3342633580</_items>
                <_size dataType="Int">0</_size>
              </childIndex>
              <componentType dataType="ObjectRef">3471896484</componentType>
              <prop dataType="ObjectRef">1804014302</prop>
              <val dataType="Struct" type="Duality.Vector3">
                <X dataType="Float">335.3355</X>
                <Y dataType="Float">-298.4915</Y>
                <Z dataType="Float">0</Z>
              </val>
            </item>
          </_items>
          <_size dataType="Int">1</_size>
        </changes>
        <obj dataType="ObjectRef">1053859381</obj>
        <prefab dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Prefab]]">
          <contentPath dataType="String">Data\AsteroidBig.Prefab.res</contentPath>
        </prefab>
      </prefabLink>
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="328270949">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="406667287">
        <_items dataType="Array" type="Duality.Component[]" id="2840848142" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="2688585881">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">328270949</gameobj>
          </item>
          <item dataType="Struct" type="Duality.Components.Physics.RigidBody" id="3391047473">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">328270949</gameobj>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="1970437517">
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">328270949</gameobj>
          </item>
        </_items>
        <_size dataType="Int">3</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="2249191616" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="2316305309">
            <item dataType="ObjectRef">3471896484</item>
            <item dataType="ObjectRef">747347734</item>
            <item dataType="ObjectRef">1441205920</item>
          </keys>
          <values dataType="Array" type="System.Object[]" id="2940304632">
            <item dataType="ObjectRef">2688585881</item>
            <item dataType="ObjectRef">1970437517</item>
            <item dataType="ObjectRef">3391047473</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">2688585881</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="2542610487">bUN4fenhbEeN44+h6eeLZA==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">AsteroidBig</name>
      <parent />
      <prefabLink dataType="Struct" type="Duality.Resources.PrefabLink" id="2330495413">
        <changes dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Resources.PrefabLink+VarMod]]" id="742840372">
          <_items dataType="Array" type="Duality.Resources.PrefabLink+VarMod[]" id="4031009956" length="4">
            <item dataType="Struct" type="Duality.Resources.PrefabLink+VarMod">
              <childIndex dataType="Struct" type="System.Collections.Generic.List`1[[System.Int32]]" id="563079112">
                <_items dataType="ObjectRef">3342633580</_items>
                <_size dataType="Int">0</_size>
              </childIndex>
              <componentType dataType="ObjectRef">3471896484</componentType>
              <prop dataType="ObjectRef">1804014302</prop>
              <val dataType="Struct" type="Duality.Vector3">
                <X dataType="Float">-36.9999924</X>
                <Y dataType="Float">-264.000031</Y>
                <Z dataType="Float">0</Z>
              </val>
            </item>
          </_items>
          <_size dataType="Int">1</_size>
        </changes>
        <obj dataType="ObjectRef">328270949</obj>
        <prefab dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Prefab]]">
          <contentPath dataType="String">Data\AsteroidBig.Prefab.res</contentPath>
        </prefab>
      </prefabLink>
    </item>
  </serializeObj>
  <visibilityStrategy dataType="Struct" type="Duality.Components.DefaultRendererVisibilityStrategy" id="2035693768" />
</root>
<!-- XmlFormatterBase Document Separator -->
