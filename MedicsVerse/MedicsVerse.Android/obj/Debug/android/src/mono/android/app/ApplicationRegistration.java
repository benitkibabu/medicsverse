package mono.android.app;

public class ApplicationRegistration {

	public static void registerApplications ()
	{
				// Application and Instrumentation ACWs must be registered first.
		mono.android.Runtime.register ("MedicsVerse.Droid.MainApplication, MedicsVerse.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", com.cedricm.medicsverse.MainApplication.class, com.cedricm.medicsverse.MainApplication.__md_methods);
		
	}
}
