﻿ALTER TABLE [dbo].[FlightVersionHistory] ADD [OGNFlightLogId] [nvarchar](max)
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201605012102550_Added OGNFlightLogId to FlightVersionHistory', N'FlightJournal.Web.Migrations.FlightContext.Configuration',  0x1F8B0800000000000400ED3DDB72DC3A72EFA9CA3F4CCD5392F26A249F97AC4BDA2D5BB64F94635B2E8F7D9237153503492C73C85992E3952A952FDB87FDA4FC424082175C1A4083042FE355E94543128D6EA0D1177437F07F7FFBFBF99F1F77D1E20749B330892F966727A7CB058937C9368CEF2F9687FCEE0FFFBEFCF39FFEF99FCEDF6D778F8BDFEBEF7E29BEA32DE3EC62F990E7FB57AB55B67920BB203BD9859B34C992BBFC6493EC56C13659BD3C3DFDE3EAEC6C4528882585B5589C7F39C479B823E50FFAF3328937649F1F82E863B22551563DA76FD625D4C5A76047B27DB02117CBF75178FF90FF677248E3203AF92F727BC2DA2C17AFA330A0F8AC4974B75C04719CE4414EB17DF52D23EB3C4DE2FBF59E3E08A2AF4F7B42BFBB0BA28C5454BC6A3FC71274FAB22068D536AC416D0E599EEC1C019EFD528DD04A6EDE699C97CD08D2317C47C73A7F2AA82EC7F16279191D6E970BB9A35797515A7CA41FE293A2E18B85F2FA45C318947F8ABF178BCB43941F52721193439E06D18BC5E7C36D146E7E234F5F93EF24BE880F51C42349D1A4EF8407F4D1E734D993347FFA42EE38D4AFB6CBC54A6CBB921B374DA5768CC0AB38FFE5E572F1892211DC46A4E1056E30D67992925F494CD22027DBCF419E93944EE5D59694A3A96020F5B77E48D2BCF8B7EE9272205D52CBC5C7E0F10389EFF3878B25FD77B9781F3E926DFDA442E35B1CD215481BE5E981D87A1AA5930FC9A61C16FB109AE15066C9C27C787C7F0FB3906255F7F326492212C4CEE852B994079BFC2ABE4BD25DB51A7D63FE29F811DE97B03563BE5C7C2151F95FF610EE997C2B57E24DFBC5FB34D97D49A28AD19B17376BBA4837C53024D0DBAF417A4F723C469FC328C933109FF2D50D132C2D32EDD3A6AF1A13EE558DA4131A6BBA4E0F5929CAF508B51FC1A849EF6124E58F5CD1A5EDD35C8F68F35A41517CA32027BD86D03A5FB5B2DFA8115A4EEAA015EAC6D36A065E44B96A07BC78F3A7214691DB5797AFAF07EFE40BB90F334A3CD95EDFC78C053E24F7AFC3F42E24D1B6BF0CA6B662FA343815972929E6F12B354BB33CD8EDEB0EDFD2A7C54377C419C037C3A3FE21C8F26FFBAD5FF439A0DE4940CBA5520077124A65CB69255289421771D4343C3259E4C861B4352F72075B1E1FC9EE96A4637494DC86D1A743D1DBE07DBDDB056134BC5044B94D16E64A4630F8DF3D867921EA54B18735D398F5D5C5B4958D6CC0EAC522C1C4D57F50759AA44F376F481E44545A8168B14F2B6126B5E011357DA7D894C68F5D0D5F91987254DE049BEF19558B0E2409EDAC84095FE3C8139B7820D295381C510EC47424C284B70E53236EFDB0B96927DD82969E3B50FCE08503B276EDE9B1D52E4FCB82ECBC043907D620DB84AF6411C7BDD4483AFE0B48E0A1AD3D88A33B197F10A0696D41D6B76A0CC29B9CCC7370371CDB5ED800FD7A08B75DFD96DE0EC4F5AF9F1A677004E3AB60C0E1ED0CD8C6701C99B7641FA4059B59AD15C5278BB7255D9D9A959E743F5BEE7314C4A4AF4188746F10406A99AD00B3B20ADB39EB8B442596FB8229F121DB42F2F605554C35D95EAB3B59E6665F83CD43A2B265722837D1116D65CE44B57C4BB24D1AEE87D95757FA8A0828D5D0BB20B3DE5131190176C3A4A717219B052897031D06A9381A8F7EDBC2827FFD218E80E6EB4E6193617C0214E2A289EE8435C204F7E8AEE1A9512C7A3455850273A0867D6EA3A2F80A897DF9A92BD69C82C0E32E34B250C07D8BA3836FD0899A42FA39D2C29A602829A362783ACACF7B792E159F74D9A72E5A4EBC4F5D1B75CEFBD4386BD0DF3E358B34A5BE22F1CE91A8DD9E50347DED5ABB5A89A3A594B08536367DE5821861473BC8B2C17BB9FE6B3C420C60949DF535DBAEEDE394BC8BEFC398F40582DDE1473B7BCFF1E063F05EDE92BB802A3EB3D1C0CC2AF5536E3313FC42DDD1843FEB16C7316FA8C3A6A56421CA3BD582A5D9C954E146A783B9D2B49ED6641116B5ABD9E2B0FDF39C10AA13665060B877A8159D0B272F5B4DAA5C8F28448FB8C33C230D23450F46DEF57FDE8F7FDE8F7FDE48FF1A64DFDF52CF3888378E7D8EB905EF335A729964B94CA9231C26A63C002AE7CD039C9F3F44A16CE76C92744BD5922343F48874205230E07DC321E3178688852D46D13D2A516C1EC00E4AF1E6A6B6825A84B8C78A7BC2BFEB94A3D23DF548332EC3063D1CF38E4C380E16CAB078983A9C060C509843128820C4E0610753A0C11A5AF0154C60DB7A1DDC8FA2E1B4CE47814117D7A36E3796375EEDC55DC71E7C87010D28CBFE5257E92DB32F24D9BB976BB4F572DD0B375A183328E160C8742EE4689B1F5939C77C3C8761769B3A95888229B0BA3AD2EE8BE84372FF8E95BD755D423584192C208A4AD875F5546D7BEC487D2059364A82D9CC1481C005804680DEC3EC2D7FE42F014A04AF18FAC06B0B867AB35FB7FE5E53EED88425629CC0686BEB451ADFC5DB85B1D09E4D7C5DA24FE79E2EAC704F9712EDFA62F96FCAA0E900361E560BB02DD216819E2DE575781DB3BD84C5EB0D3B81E432C836C156E52B3A265BF1095DBA242DD44C105DD2A9A2C2208C73759D87F126DC07910975A911281EF445DB05724D37F29BB7644FE242199AE6A27FFF4D37D2A0D9C6E87CC5319599D7B8E2321D5F4095662D53546B06CF66D0990C66A69D9EBF549C31930B9F15E3C458EAD8F7EB78048E3266F4EA980297DEDBB2095CA98367425C51A285CBCF940E3A31170617CCAC6BCABD9DF80D330F185CB8ADF6F93061B3CBE9C415EA06E8C06CA8ECA82254F0E9C9C990DC28A334A26A45CD090A1F2EA0361F9E6482C5893F243374606E94EA6B2714890226930A4461067A623229E3350104779650630B6330A25A496D61C881052388D4F4BC294F0E1A233E8162125E9532B0741CA24BC76AB9810BA4E0194F77E299D93FF1C76370FF23F91AF098CEDEDFD0A4DE6ADD4F4B1E2E274F58F8D2C1B335E7EE6298D31F2B9991C1CCAA21C7D5CD87358EB8074C4653A14837D6EEB8BA2BC3699DD369DDD1E37540B12E27C2C9ECC032737024A7771D8FD359E4A3E8BA690643EAED14B3340E3CD780F955363654F9C57D91607C609BD7DB61794CE8D94EE9CB1EA7F7EAE4AF623DD4AE4C33B9173A07BFF3D83D4D2149D136EB62C6A20F3E12ABEC2C5EC7F41130086DD45CC3B5FD9DF88D9F849E7D8FC75F7CCAA98527C0FC530FBC0625AD1E45585F8FFFF85624303968D7B5AD089A9C138D7B23FA3C635F5CE8BC21322F269C6A0B453731C7B479029E6C64E619F3314743C71B8E52439B8818575F9B26EF58B4B7E1442B275E426976CFFC7BE45ADF4ECDE836807D528FCB22D09E71E6CE67666B6108CE3E5A4BC246CCF876856D428FC3CA00AB29747C652EAD907673F88222C73C57ED055F6345944D5860E6D5570EAB66ACFBA1305A7E347F40BD71BEE1D3EA7B674B4327DCE3B9B4D71E3D58C561C4565BD22121DC9618390E87AE1CC4EAA5FA1A0573C0C25834E27D0C5CA318BE94A076F058954B7973651893543AEC22CEC92374B6D1B78C54756559558224935F405D939C130AD972D196D408D254193BB1716D1542005ABBD802A4BE6A4581500DBCA5B9A07A2130B0E96443AA709A40A498D36A69CE5F15A980E02C2B146D7AA2AC00AAB32194E62CA4899918E17A4E788A78818901592DB9500FB15DCD123C6EA9882CCC5DA1CA7DC3F1B2A60E4C10087025584343B35814056AABFDE240704B46960B227108C2B99A23806A5D4512A01605AB8D43B65E9A0682812A24DB8075A0D4580B03D08EAF9DB17B49721212479E2C7B0CE3842A94B10EBDAFA16BCFA9418E1D9C7F63A750C9C7F1387A4A5ACE40CBCC506F801D3EC0D0416C9C0A168FC781134D9DD1984E3A6AC765E8E07C0524A54AFE82EFA154D218861852F9484D75F84C29DF02259AA46F0E6BDE7E310C8926CD7B0005A03B1718507B8834665183991399F9B9AC8C42933A34A72EA386B8F37AB36B44B40EB46B3DCC621951C121541A5E8921D4168AFCB134947054904ABE360752C019CA82E4F0AD5C0903D150DEA37DDCBACFB845052395AE4DCDA2267A2C8D8AD5A18E5A13AB27F163318A4A1432CF0C63A146C841BC85A87847DA8558B7557574A75938804F4BB936CE0AE10EC556BB8D0214311DD436BF315A04E6B41D2D013A2BC07520463400E04BAFB086366A991853497C1AD623AD24D35D5BC881735965887C068F8338FA42D4DFF6E53296A8456A8D9EFB1EC751D6317C949D6673CF18A4C5876965D52C6CF9DAB6FE7481D9217C402584A8DDF5D4C6199191C62E7BA0506CD16168BB0E8872309C664C8CA1477CF051A688DFCCB70D912EDE388893009E48671B1B9BCB600A497A19197F8E447D4C5E13406CDE9DAFD69B07B20BAA07E72BFAC986ECF34310B17327EB171F83FD3E8CEFB3B665F564B1DE079B22DAF187F572F1B88BE2EC62F990E7FB57AB555682CE4E76E1264DB2E42E3FD924BB55B04D562F4F4FFFB83A3B5BED188CD546589A72B8B3E9890AE0E09E486F8B3BFCB6E47D9866C55562C16D509CBC78B9DD299F89E1524D70AAEE8B8F88AA135607AAEAAF8BFF79DD079CDF0949E57614DF53C276457A47794AAC2430D566B4E17A134441AA3953F532890EBBD89CEAA187C25D6BC403E21EE361A9605C21F0E9863C1C531AA21E1A9D912CCC25949A877838BF875958DE07C1C3691EE2E194FCB9C9AFE2BB24DD55514B61F680F72AF4F395C44732CBAE149E551211C405805A1EADD1E86589E8C2B28865A26F3A0E5BF567F3ABCBD7D72204F6040F815DA44A52B2BDBE8FD920535DF23A4CEF42124954DABE7561E0030BCF8B5C7B8062F64638CAD58C0240E5AD33E437328EED63076104DEC228F00FF845A71E648CA557B31103953DE24506805617420068DAE946B929D9E5C7575BC7AB87D37FDD7F8B0121D43CC4C3F94876B7EC6C0E1E50FBD40152721B469F0E45430918FF020FEFDD2E08231152F5C8610D7B316C58AA93305B40F2939196E6C25A819CE6E96CD6A4B4CDE1656D82D973EE4B1507463703ACB5CC0BED5367BD006A051738F2ED883C38F99D83119E2B6C563DC2C3503955C7A55A08EDAD770298F6B18B66AB6EC113755AF5D0194E75D32200AC7A8387D894C509DA40572B6780E349AB28873928F04C273D1879AA2D2891384B5F69A287C71D08C543339C1365C1AD2DE152B0D357779939A53E7148E613DD49447A68F235903C44F99D23547069886F5CD62C776985B86AB9172EF0AA2B0C4558D5C34E96ADD6AEFDD92D6516B0F2632943313A8CA50CB71B5A36328F3305B638C4372E9EE76E4F285980FD2CBD9A66EB8B05BB84150DE4C59B2094332DDBE0E52317CB39C832D9702E1F3958387F8D655FA07A34A6EDBDA6FA4EA2A47AE460BFC7F761193216CCF7FAE1907EC0583AF9791FE568B503173DF6A221B40174849630B41D8B93E7158670DB8198D4EBF7EAEE7776F0A770E98771C59FDD681CC46737BAA3A07B767D3DB9BE5F83ECFB5BEA4C04F146C1927F339D33ED7DCBE432C9728067D8633CAC3A394206C63F779C591518F7F81F7BFB41EF246F9274FB1B91E0718F67636AB01A102F8646E908BA9B19703393FF29AF3AF866731314EE8E71C007BA76DC57EB265AA68CF2F2498BFEE2BDDCA9011D23BF260846F360DD5CE4AD1807EDAB31FD0CDF0AE728FC163949D21F6B35C74774642C7D7B235B55375C2B3C05DE9A6D82565F742DA897EAD9F18B1A31635555304D2233528B34DF63744591780B28092923591D13671FF646EFCA962700D5A0DCF0D39EF6D55BFD1991BA4CA8555E9EE274951597B637979D3BD02DA72A3BF30690FE8F1508622B541A113011DA347FE474E074CF8D450F39728FB6C6C10569B45FDE9F8BD023E1879F94EA09571DA3953E464DA29B284D85C4ACE491A93CC485A91CD5A51E4BCF9C50958A383342D5CE2F1F08F520BD97EC4DB7858B4372DE2CA094C3C89F34664FF5A4F9DD94C354A528428D4C495E51F1529295556531726D0AFB64B9A0B8FF08B7455DCAFA29CBC9EEA4F8E064FD97E8320A49B1EF5A7FF03188C33B92E55F93EF24BE58BE3C3D7BB95CBC8EC22063654B55D5CD2BF9F83F5419CED92F45190ED9EE567273F7629E024A966D23A094A758409C3F2215DFFC461436C39E587ABE921B9F6BFC1F76AE5C18D7CBF2574227BE70DA3F07794E523A5C57C5A9A714D9E5A2D048C16D51915569A595B10B2E22C57A897F04E9E62148FF65173CFE2B0FAE3C84D102CD1B20BE9281A35E3926F22ADE92C78BE5FF94CD5E2DAEFEFBA66DF962719D521E7CB5385DFCAFF3B83465351E88694A6B18ACDB307746072AA571C68CF7788C7C0E57A4E0785D5F8362E777CDACFBE6796F5CCAAA5C3C00B295B4F4619CAA9AC503966A0206035A6C16E76131A6AEC8B5E9173E64069875D11345693B7CB83507786FB805A7B185ECABAD6938F55243416ACA4A3C704A5B59E203185F59E2015E555FE263BDAAE6034281B256BD9427CB8EF331164D529A7E1963E018BC71B7C1D102D28D570F8960AF35C1090883C70C98AA700D895D9AB4BDB0113DC4E15F0E242C0507D5626957E5D05B82CBB9331ED8B22A66F100C9C6DC280AB904867ECBA4C95AF002A6CAC1E11698235D4DFA8DE31A65CD7A4930483762C5838FAEF9E49E0E28B4CDF1720964F33625C80D0BAE69AFC1E0724BDC10681AF6EA5E4A61EA300675E35E68F0894F8EDE70D3B20F23C869520C87BB2809F24EA02439D3099010FDF32189EBAC9CBEB28F4BC8391ADF03B87B11E77BC0099208DF0310EDBE7D0FB136C7870F2295E6F800E977FF8D15E9F8C0ABAAD5F1E28594153B1E2055753B3EF6297D392855114F771BA7A9DFE901C2939334ACBA7FDE60B2021D56C8EBAE7344097A4376B85DD8EB18EB1F249631C4364CEF6D059F1B09136C0E0CE0D43FBBE2CFAEF8B32B6E41E1D9179EA32F2C1608CDC8A99EC3F60DABD9D10C0A0A0C5F47D4070E5742D407CC4FB8530139EF4DD910566BA12D2035A11A67FFC039C776EBA76E37A0E9CB15F1F4B660FC8A00256D53670122A482046B00E3D85890E3108FD767FBA2A2F2607872B66930BE5966660E9321F3D58123C05C50243B546D3DF94E7509CE0C677E02618177046EFA78221DFC111D83AAB7911B2E06E64EE86FAF1666F84BD75B0F7531B88003BB0784EB9F3DB05D764ED712498BD90FA2CB242E36F543B59EEB731AC69B701F4432BDD287E01A351D9D7DBE6A40CB6FA82340E2822F79FAFAF7D7809546D6360EAE37D803F7ADB84ED6408CC2552F98EEAFF7C42AE869D3559F3AB088EE946897CE46E00FF00221F0DA4DF7593B5366CD7C71910011FE6010B6C04F95A12005CD18C8238AD5CE0D07704CC72AF025A55DD5D1E9C9C9B130CD146AA733EB988ED4998E77A05CE8672133AD9031743E299BC097C3BAB3CB11499863E218D32965A3708EE93679575BD7C223DC35911C20EEE9D1DBAEA653396766BFC237D86BE7DF71EE2C9C50DD58CBCB1CF664100E709B15E3417F2E7E8CE60C6FE71E47531FE3B92F8066F88974C111392553B821E34DFE74AEC6713817FCB14ABDE7CC32F77C4A6909853D1864DE1DE6C0745C0A7ACE35871CEA7A339ED132DED21FC98B7C96F5B3F00D27F0069F677E263E5ECD0140198BB34D3E503C63748E415BE7DA43CE07E2187D77E3710A978E38EB70E9B341A93A92FA13E547E7209F3B0A3F09074DB317E1CA4333D88C90F7B267AFBB66B2F73D815EEBB2F73D032D2771D871E9BC7970DB51C572E7A31D21CE3B1A5D390FCE9B528F76E5BD49B5AA94B93D7CB44F4E1557F614F877471FF9B3DF7531B7F89F7260FA0013896191D19218BB4C91F590F601D21A9D0E891F8B53E473D07BFB5356BE682A0A14FE68DFFC14D103DB5D26730D2340C7A2F75CE943264B4FC64FE36E4EBB7393F5C878EFBCF44E3CA2BD5687F271EA0A375587ED73EA73B9686B400453851DC57EB1DCDE2674C2590D49F146B9095A01DBBA730AE8F61504BE7E6BEFA2E27D057E7DB50000BC7C65870C5BE04A47F06750BFF09736FAD8E68B4A1F7B0ED257BCB2D3C7B93C0A74EE1DD4037703336E14B5E3661A293B7016F75640B3C71060761B1F8AA7784B0CE62EFE0B2D9FF137C1A1FA6D2528DC6BFB5EDB27774398DCA578E70358D3B5E0BEE1E480A6E84BB3A7D390C63F54C4A1EC2571ADD803593189E82348E34A8F00BA748549EEA8411A9A6B523DE94D8EB1520620105F59D38500C48E06070225FE3C0D49938A851D133877CB1373CF6A68AA99448E0B6870FD4C9C22A672380D0B9C0072B4C32365AF034361CA6FEF29321563A46CC63DEDAF09E0246D482B20D2B9FB202F72086FDF310E614F3CB1BB5D3B0CAA0F00C6F5479A5DCA8F21D7872151B8A653254F9B6EDA0D41A1156F55B7B7827A9B358B021A50E50CCA8C48453282EA18964C269DF4E441417377793736597CC45A4F9C36AE7D0402454926B29039A0CE1B9E4C30E3056DDC0DC6C233B17951CC8E4DE9F8197D24C422C1E51D785E32E30F0F18EAD6EDA41843E23EF654D43DB95631F2EF3C6D1BF1115DEDEE9136ECEB0BFD91B696C0D0A48E6A6308D383090AEE84027703FB265B6B9B5A0374BD6D37FF242BF7F736EFCE576CEFB87A407F2AF7F49EAFBE1CE2E25447F6EB2DC9C2FB16447131794C364230AAF9A6B839B40E8D4918D59FC83740500F741BE4C1EB340FEF824D4E5F6F48969567D5FE1E4407525C55774BB657F1F521DF1F724A32D9DD46C26014B13553FFE72B05E7F3EBF238B9CC070914CDB03808F33A7E73088B7B342BBCDF0387AD69401441BBEACCC5622E8BEB44C8FD5303E95322DB183A40D5F035B1C6AF64B78F28B0EC3A5E073F4817DCBE65E403B90F364F9FABEB96F540EC13210EFBF9DB30B84F835D56C168DBD39F9487B7BBC73FFD3FE57B219CAE410100 , N'6.1.3-40302')

