﻿ALTER TABLE [dbo].[Flights] ADD [OGNFlightLogId] [nvarchar](max)
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201604171422010_Adding OGNFlightLogId to Flight', N'FlightJournal.Web.Migrations.FlightContext.Configuration',  0x1F8B0800000000000400ED3DDB72DCBA91EF5BB5FF30354F9B2D4723F9BC6C5C5252B67C89F6D896CB639FDD37153503492C73C809C971E44AE5CBF2904FDA5F5890E0059706D020C1CB382ABD6800A2D1001A7D417703FFF78F7F9EFFE971172DBE93340B93F862797672BA5C9078936CC3F8FE6279C8EF7EFF5FCB3FFDF1DFFFEDFCCD76F7B8F8ADFEEE97E23BDA32CE2E960F79BE7FB15A659B07B20BB2935DB849932CB9CB4F36C96E156C93D5F3D3D33FACCECE5684825852588BC5F9E7439C873B52FEA03F2F937843F6F921883E245B12655539AD599750171F831DC9F6C1865C2CDF46E1FD43FEDFC9218D83E8E47FC8ED096BB35CBC8CC280E2B326D1DD7211C471920739C5F6C5D78CACF33489EFD77B5A10445F7EEC09FDEE2E8832528DE245FB397640A7CF8B01ADDA8635A8CD21CB939D23C0B35FAA195AC9CD3BCDF3B299413A876FE85CE73F8A5197F378B1BC8C0EB7CB85DCD18BCB282D3ED24FF149D1F0D942A97ED61006A59FE2EFD9E2F210E587945CC4E490A741F46CF1E9701B859B5FC98F2FC937125FC48728E291A468D23AA180167D4A933D49F31F9FC91D87FAD576B958896D5772E3A6A9D48E0DF02ACE7F79BE5C7CA44804B7116968819B8C759EA4E41D89491AE464FB29C87392D2A5BCDA927236150CA4FED60F499A17FFD65D520AA45B6AB9F8103CBE27F17DFE70B1A4FF2E176FC347B2AD4B2A34BEC621DD81B4519E1E88ADA7513A799F6CCA69B14FA1190E25962CCC87C7F7B7300B2956753FAF92242241EC8C2EE54B79B0C9AFE2BB24DD55BBD137E61F83EFE17D095B33E7CBC5671295FF650FE19EF1B77227DEB45FBC4D93DDE724AA08BDA9B859D34DBA29A621816ABF04E93DC9F1187D0AA324CF407CCAAA1BC6585A64DAD2A6AF1A13AEAA46D2098D35DDA787AC64E57A84DA8F60D4A47A1849F923577469FB34D723DA542B288A350A72523584D6F9AAE5FD4689D0525207A950379E5632F02CCA553AE0D99B3F09310ADFBEBA7C793D78279FC97D98D1C193EDF57DCC48E07D72FF324CEF42126DFBF360AA2BA63F061FC5654A8A75FC42D5D22C0F76FBBAC3D7B4B42874479C017C353CEAEF832CFFBADFFA459F03EA7D0868BE5432E04E4CA96C392D472A51E8C28E9A8647C68B1C298CB6E659EE60DBE303D9DD92748C8E92DB30FA78287A1BBCAF37BB208C86678A28B3C9425CC9080AFF9BC7302F589DCAF6B06A1AD3BEBAA8B6B2920D68BD582418BBFA3315A749FAE3E615C98388722B102DF669C5CCA4163CA2A6EF149DD2F8B1ABE22B0EA69C9557C1E65B46C5A2C3908476D681095FE3862736F13048D7C1E106E530988E8330E1ADC3D4885B3F6C6EDA45B7A0A5A70E143D78A180ACDD7B7A6CB5DBD3B2213B6F41CE8035F036E12B99C571951A4EC77F01313CB4B607517427E50F0234AD2EC8FA569541F89093590EEE8A63DB0B9BA0778770DBD56EE96D40141431BCE08785BE23AAAFC93E488B75B7AA0F8A91146FCB71756A569AB6FD94AB4F511093BE1A1AD2DE4000A999A802CC4A2AEC28AB2F12159FEC0BA6C4876C0B56D81754B1D4647BAD1E2D999B7D09360F894A96C9A13CD546B4952913D5F235C93669B81FE6A05BE92B22209B411F4BCCFA88C32495ED9A424FB55E96D3281B00ED97A8281A8F7EDBC2827FFD216E00CDD79DFC18C328E928C4459DD9096B844EECD17EC28F4651B1D1A32A0498C368D8E7B651145F21B12F3F75C59A131078DC8546961170DFE2C6C137E8349A82FB398E8535C18CA47453E1C7517EDECB94A8E8A4CBC171D172E283E35AA9733E38C66983FE0E8E99EB27F5E51A77760DEDF684A2E9EB18D9554B1C2DC6836DB4B1C7576E88118E98832C1BBC97EBBFC6231CCA8F72D4BD66E7A77D8C9237F17D1893BE40B047EE6863EFC9417B0CD6CB6B721750C167561A985AA57ECA9D2E825FA8478CF067DD1C2BE6136E58B5943444F9E858D0343BA92ADCEC7450579AD6D3AA2CC2A676555B1C8E7F9E223475CC0CF2D4F6F67DA283D3E46DAB895DEBE116E8E10898E7D1FF48C7F9D7EF3E36315923C4403C9DC73F9DC73F1DA47F09B26FAFA9651CC41BC73EC73C82F7E92DB94CB25C1EA9231CC6A63C002AD7CD039C9FDF45A11CE76C92744BC5922341F4F074206222E073C321FD17068F85CD47D1DD2B511C1EC0064A5173536B412D425CB1629EF0759D8246BAC70269E66558A78763209009C7C15C19160B5387D3800E0AB34B02E18418DCED607234585D0BBE9C09EC58AF83F951349CD6F82830E8627AD4EDC6B2C6ABB3B8EBD883ED30A00265395FEACABD65F285387BF7FC893681AD7B26450B630639150C99CE99156DF323CBAF988FE530CC6953A79C4D30265597D8D97D13BD4FEEDFB03CB4AE5BA88630830D445109BBEE9EAA6D8F13A9F724CB4609309B992010A8009008503D4CDEF247FE02A044F08AA20F545B30D4ABFDBAFDF79252C7262C11E318469BEC2E8EF14DBC5D1833DFD9C2D739F374EDE9C60AF7742BD1AE2F96FFA94C9A0E606361B500DBAC6911E8D952DE87D7313B4B58BCDCB02B412E836C136C55BAA273B2154BE8D62569216682E8922E156506619CABFB3C8C37E13E884CA84B8D40F6A0CFA22E906BBA916B5E933D890B61685A8BFEFD37DD4893669BA3F3154754665AE3B2BD747401A57EB54451ED193C994197249889767AFA5271C62C2E7C798B1361A973DFAFE31128CA18D1AB230A5C786F4B2670EA0C9E08715982162A3F533AE8445C185C30ABAEC9BF76A237CC3A6070E18EDAE74384CD29A71355A807A00393A172A28A10C1A727274352A38CD288A215B526287C3887DA7C6892311627FA90D4D081A9514A789D90250A984CCA108515E889C9A484D73810DC4942F52D8C41886A6AB3852007668C2052D3D3A6BC38688CF8008A4968558AC0D251882E1CABA506CE9182273CDD156466FBC41F8DC1FD8F646BC0733A7B7B43137AAB353F2D71B81C3F61EE4B07CBD61CBB8B214E7FA4644606B3AA861857371BD638E31E30194D8422CD58BBE1EA2E0CA7354EA735478FD700C59A9C0823B303C9CCC1909CDE743C4E6391F7A2EB961974A9B74BCCC238F05403C657D9C850A517F74D82B1816D566F87ED31A1653BA52D7B9CD6AB93BD8AB550BB12CDE456E81CECCE63B734852045DBAA8B118B3EE848CCB2B3581DD37BC020B4516B0DE7F677A2377E117AF63D1E7DF121A7169A00E34F3DD01A14B47A146E7D3DFEE36B91C0E2A04DD7362368724A349E8DE8E38C7D51A1F381C8BC8870AA2314DDC21CD3E10978B3919966CCD71C0DED6F384A096D1AC4B8F2DAB478C722BD0D375A39D1124AB27BA6DF2397FAF6D18CAE03D817F5B83402ED1D67EE7466D61686A0ECA3D5246C83195FAFB02DE87168196036858EAECCA915D2690E9F50E418E7AA7D716B2C8FB2090BCCBAFA8A61D5CC753F14468B8FE66F8C37AE377C7D7CEF6869E8CA793C95F63AA307B3388CD86A533A2484DB1423C7E9D0A58358AD545FB3607658189346BCCF81AB17C39710D44E1ECB72299F920C63924A975DC4397984EE36FA9A912AAF2CAB5290E4E11750D724E79842B65CB42935023755E64E6C5C6B851080562FB600A9DF3E512054136F692E885E080CAC3AD9902A8C26102966B45A9AF36F372A2038CD0A3536FDA0AC00AABB2194E6CCA5895918E1BD4C788978868901596DB9500FB1DDCD123C6EAB8824CCBD69CA7DC3D1B2260F4C6008702658338666B32802D496FBC581E0B68CCC17C4C12106CEE51C01A3D66524016251D0DA3864EBAD6918309085649BB00E2335E6C20063C7E7CED8AD243908891B9ECC7B0CF3844A94B14EBDAFA96BEFA941CE1D1C7F631FA1128FE371F694B09C81B69921DF003B7D80A283383815341E8F1327AA3AA3119D74D58ECBD4C1F10AC8912AF10BBEA752096318624AE52B35D5E933857C0B23D1047D7358F3FA8B614A3461DE030800DDBDC080D84384318B12CC1CC8CCAF65A5149AC4A139741935C59DF79B5D22A265A05DEA6136CB88020E21D2F0420C21B650C31F4B42095705A9C3D7C6400A384351901CBE952961183414F7689FB7EE2B6E11C148A16B13B3A8851E4BA26265A8A3D4C4CA49FC5C8C221285C833C35CA81E72106FC12BDE71EC82AFDB2A3ABA8F59B8804F3B72AD9F15C21DF2AD769B05C8633AA86E7E63D408CC613BDA01E8B400D789185101801FBDC22ADAA86D620C25F1A9588FB4934C6F6D2127CE659721E2193C4EE2E81B51FFDA97CB5CA236A9D57BEE7B1E47D9C7F055769AC33DA39316EFA69545B370E46B3BFAD3396687B0011517A2F6D453EB67447A1ABB9C8142BE4587A9ED3A21CAC5709A3931BA1EF1CE477944FC61BE6D8A74FEC6418C04F0463ADBDCD84C06934BD2CBCCF83324EA6BF21A07625377BE5A6F1EC82EA80ACE57F4930DD9E7872062F74ED6151F82FD3E8CEFB3B66555B258EF834DE1EDF8FD7AB978DC457176B17CC8F3FD8BD52A2B416727BB7093265972979F6C92DD2AD826ABE7A7A77F589D9DAD760CC66A236C4DD9DDD9F4441970704FA4DAE20DBF2D791BA659F19458701B14372F5E6E77CA67A2BB54E39CAAFBE23DA2EA82D58EAAFAEBE27F5EF601F777425CB99DC5B77460BB22BCA3BC255662986A33DA70BD09A220D5DCA97A9944875D6C0EF5D043E19E35E20171C578582A1857087CB8210FC71486A8874657240B7309A5A6100FE7B7300BCBF72078384D211E4E499F9BFC2ABE4BD25DE5B514560FA857A19FAF243A924976A5D0AC1288206E00D4F66895462F5B44E796456C137DD371C8AA3F995F5DBEBC1621B0123C04F6902A49C9F6FA3E66934C65C9CB30BD0B49248DD2F6AD0B011F987B5EA4DA03E4B337C2519E6614002AB5CE905FC938B6C50ECC087C8551A01FF08B4E3DC8184B55B36103953EE28507805A17820168DAE966B949D9E5E7579BC7AB87D37FDF7F8D0126D414E2E17C20BB5B7637070FA82D758094DC86D1C743D15002C657E0E1BDD905612442AA8A1CF6B017C586853A09AB05043F19C7D23C582B0CA7299DCD9E948E39BCEC4D307ACE7DABE2C0E85680B59669A12D75960BA054705297738520AA223C0C95A674F4A485D0BE4F2780698B5D6450F55E9D287DAA426738D59B8800B0AA060FB1496013F8B62EABCD00C713FF57AE5D50E099EE6430D2549BFA2151963E27440F8FBBBA898766B8D1C9825B9B6CA560A7CFC332534A7D37904C27BA3B83F4D0E4071B7988729D2354706B88352E7B967B5E42DCB55C850BBCEAB141115655D84907D56AA03FBB4ECB5C4B7E745AC89B86D169E17643F346661BA6C0618458E36223EEF6840E0BD074A5AA690EA9985B4AD8D14004BB0942B9D2B2B65C16B9E8B84196C92A6E59848771FDD758D6DAABA231B5E4359577D248AA22074D3BBE0F4BE7AEA068D785436AEC63C9E4A7138FA3950E9C9FD78B84D0BABA1152C2D0762C4A9E97C3C0EDAC6052FBDCAB61DED9149FC2F8BE7EF7B1397696E1C9754F66F493193D0F33FAC9F4F565FA7E09B26FAFA93111C41B054BBE663A63DAFB91C96592E500CDB0623CAC3A8C4106C6973BAEAC0A8C2BFED73E7ED01BC99B24DDFE4A24785CF16C540D96ADE145D1280D417735036E66B23FE55D07BF416E82C2BD060ED840D78EE76ADD58CB94FE583EBCD09F6796CBEFEFE8A3354130AA07EBE6C96D453968ABC6B4337C0B9CA3B05BE470467FA4D55CF4D091B0F4ED8D6455BD45ADD014F8BEB5095AFD24B5205EAAB2E36735626CA92A609A9063A41469BEC7C88A224416101252ECB03A27CE36EC8DDE942DEFEAA941B9E1A7BD97ABB7F83322759950ADBCBC6FE92A2B9E576F9E257718B71C54EC4C1B40A03E962188AD50013FC0426803F291CB81933D371639E4483DDA6C0417A4D176797F2A42CF841F7A52F21C5C658C96FB1825896EA134B90CB3E247A6440E17A27214977A2C3D534295D4E14C08553BBF7420646EF4DEB237DD362E0EC979938092B8227FD2A83D5549F3BB495CA99246846C967278456E4A39ACAC4A6091B348D827CB05C5FD7BB82D3248D63FB29CEC4E8A0F4ED67F892EA39014E7AEF5071F8238BC2359FE25F946E28BE5F3D3B3E7CBC5CB280C32966054E5C7BC902FEA4325CC9CFD5224CC90ED6E2537774FBB29A064D93602926E8A0DC4D923529ACCAF442133ECDDA2E72BB9F1B9C6FE6137C08571BD2DDF11BAF085D1FE29C87392D2E9BA2AEE27A5C82E1785440A6E8BDCA94A2AAD8C5D701E29D64BFC3D48370F41FA1FBBE0F1773CB8F2BA440B346F80F89C036EF4CA858E57F1963C5E2CFF56367BB1B8FADF9BB6E5B3C5754A69F0C5E274F177E7796912603C0CA6498261B06EC3DC191D28E9C51933DEE231D2399C3B82A3757DB6889DDE35ABEE9BE6BD5129CB47F100C8967CD28770AABC130F58AA01180C6871589C87C59CBA22D7865FF8E01960D4454F14A5E3F0E1F61C60BDE1369C4617B2EFB6A6E1D45B0D05A94900F140296D0E880F607C0E8807785526888FFDAAAA0F0801CA5AF5129E2C3ACEC75C344169FA6D8C8163B0C6DD26470B48375F3D38823D2B04C7200C1633A0AAC2D91E766ED2F6C266F410877F3990B0641C548AA55D85436F0E5E659E78A0461B25A2D0E1A20DFAD1741362E0054C1530C3ED06C77135B1328E1B8A35EBC56E204186DDCB3EBAE623713AA0D036C7331190CCDBF81D372CB8A6BD26830B047143A069D8AB7B29DEA8C31CD48D7BA1C14729399AAE4DCB3E8420C734311CEEA224C83B8192F84C274082ABCE0727AE4368FAF23E2E7AE6680C05E049439CA1004733220C0580B5FB3614C4441A1F06839447E303A4DFC3329651E303AF2AB1C68BC950A6D778805425D9F83854F4654D541937DD759C26D9A607084F16CDB0E2FEE934C80A745826AF7B2511C5E80DA1DC7666AF23AC7F11C7C3106726BDCF007C5AFD1358F272F6CA93296E04F3648A3F99E27DD7E1C9169EAD2D2C66F3CCC8A89EC3F10D4BB0D14C0A0A0C9FF4D3070E97EFD307CC4F78520119EF4D8E0F566AA1352035FA19A7FFC001C276EDA76E37A0EACB65DCF4D660FCB20025C652A70122B882046B00E5D8983DE3E03CD787E6A25CE8A02F71B6312BBE4966660693214CD58122C0C04D2439546D3DD94E75BECC0C577E02668137046EFA58221DEC111D81AA8F7C1BDEDBE52EBE6F5FEC65F84BAF460FF5DEB680037B5E83EB9F15D8DE10A77B89A4C5EA07D165121787FAA19A7CF5290DE34DB80F2279BCD287E01E35DD487DBE6A40CB35D41020714197FCF8FAF7D7809566D6360FAE0FC303CF98B82ED64084C2A51A989E85F7442AE865D3A58A3A9088EEF26597CE46A00FF05D1EF0354BF7553B5356CDFC1E900011FE6010B2C02F95217B044D18C89B7FD5CE0DB7654C472AF0DB9F5DC5D1E9C9C9B110CD1462A733E998EEBF998E76A0C0E52726332D9331743E2999C06FAEBA93CB11719863A218D39562A3508EE99176575DD74223DCEB8B1C20AEF4E87557D3159A33D35F31CFD2775F3B0B25540FC1F23C87950C42016EAB62BC95CFC58ED15CB8EDDCE368E2633CF305900C3F912C3822A3640A3364BCC59FCED4380EE382BF03A9F79A59D69E0F292DA1B08241D6DD610D4C779BA0D75C7323A1AE37E3852AE36DFD91ACC8275E3F0BDB70026BF069E56762E3D51400A4B138EBE403F93346A718B476AEBD917C208AD177371EA570E188B376973E2994AA21A9BFFE7D740AF279A2F09350D0346711AE343483C308F92C7BF6B26B2667DF13C8B52E67DF33907212851D97CC9B07B51D952F773ED211A2BCA39195F3A0BC29E56857DA9B54AA4A91DBC37BFBE45071E54C81AF3B7ACF9FFD618AB9F9FF94DBCD0758480C898C16C4D86589AC37AA0F10D6E874A3FB5894225F5ADEDB9EB2D2459351A0D0475BF353780F6C0F8FCCD58D00DD61DE73A70F192C3D193D8D7B38ED4E4DD6FBDDBDD3D21BF13EF55A1CCA779F2BD454DD8CCF89CFE5A2CD01115415766FFAC5727B9BD005673924458DF26CB302B635E714D06D1504BEAEB57751D1BE02BF7E0700005E56D921C31AB8D211FC19D42FFCA56D7CECF0451D1F2B07C7C79EBAB741E64C1E053A5707F5C03D978C9B45EDBC9966CA0E9CF9BD15D0AC1802CC9ECE43D114AF89C1D4C57FA1A533FED93654BF2D07857B6DEBB57D72CF79C95D8A0F3480395D0BEE1B8E0F6892BE34673ACDD0F842851DCA5612D78A15C88249441F31342EF50818972E31C91D354842734DAA92DEC33166CA0003C467D6741900E244830381627F9EA6A409C5C2CE091CBBE589B8673535D54A22E70554B87E264A1143399CA6050E0039DAE991A2D781A930C5B7F764998A325236E34AFB4B0238481B920A8870EE3EC88B14C2EB778C4258892772B74B8741E50140B8FE8666E7F263F0F5618628BCA9A90E4F1B6EDA0D41A115AF55B74F787A5B358B001A50E40C4A8C48413282E81876988C3BE9870739CDDDF9DDD8C3E23DD6FAC169FDDA47C050946022CB30079479C30F138C78412B778391F04C745E14B163433A7E461B09B1497071079EB7CCF8D303BABA7527294697B88F3315F54CAE158C7C9DA76323DEA3AB3D3DD2BA7D7DA13FD2D112E89AD48DDAE8C2F4A0828227A1C043BEBE87ADD54DAD0EBADEBA9BFF212B8FED3675E72B76765C15D09FCAA3BAE7ABCF87B8B8D591FD7A4DB2F0BE0551BC221E938DE08C6ABE299EF9AC5D631246F527F20B10D402DD0679F032CDC3BB6093D3EA0DC9B2F2AEDADF82E8408A77E56EC9F62ABE3EE4FB434E874C76B7913019856FCDD4FFF94AC1F9FCBABC4E2EF331048A66585C84791DBF3A84C5A39715DE6F81CBD634200AA75D75E762B196C57322E4FE4703E96322EB183A40D5F435BEC62F64B78F28B0EC3A5E07DF4917DCBE66E43DB90F363F3E556F23EB81D817429CF6F3D761709F06BBAC82D1B6A73F290D6F778F7FFC7F7E2F2DA496400100 , N'6.1.3-40302')

