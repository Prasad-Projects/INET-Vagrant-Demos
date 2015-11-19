/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.0
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

namespace BerkeleyDB.Internal {
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
internal class DB_ENV : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal DB_ENV(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(DB_ENV obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  public virtual void Dispose()  {
    lock(this) {
      if(swigCPtr.Handle != IntPtr.Zero && swigCMemOwn) {
        swigCMemOwn = false;
      }
      swigCPtr = new HandleRef(null, IntPtr.Zero);
      GC.SuppressFinalize(this);
    }
} 

	internal DB_TXN cdsgroup_begin() {
		int err = 0;
		DB_TXN ret = cdsgroup_begin(ref err);
		DatabaseException.ThrowException(err);
		return ret;
	}
	internal List<string> get_data_dirs() {
		int err = 0;
		int cnt = 0;
		List<string> ret = get_data_dirs(ref err, ref cnt);
		DatabaseException.ThrowException(err);
		return ret;
	}
	internal DB_LOCK lock_get(uint locker, uint flags, DatabaseEntry arg2, db_lockmode_t mode) {
		int err = 0;
		DB_LOCK ret = lock_get(locker, flags, arg2, mode, ref err);
		DatabaseException.ThrowException(err);
		return ret;
	}
	internal LockStatStruct lock_stat(uint flags) {
		int err = 0;
		IntPtr ptr = lock_stat(flags, ref err);
		DatabaseException.ThrowException(err);
		LockStatStruct ret = (LockStatStruct)Marshal.PtrToStructure(ptr, typeof(LockStatStruct));
		libdb_csharp.__os_ufree(null, ptr);
		return ret;
	}
	internal List<string> log_archive(uint flags) {
		int err = 0;
		int cnt = 0;
		List<string> ret = log_archive(flags, ref err, ref cnt);
		DatabaseException.ThrowException(err);
		return ret;
	}
	internal string log_file(DB_LSN dblsn) {
		int err = 0;
		int len = 100;
		IntPtr namep;
		while (true) {
			namep = Marshal.AllocHGlobal(len);
			err = log_file(dblsn, namep, (uint)len);
			if (err != DbConstants.DB_BUFFER_SMALL)
				break;
			Marshal.FreeHGlobal(namep);
			len *= 2;
		}
		DatabaseException.ThrowException(err);
		string ret = Marshal.PtrToStringAnsi(namep);
		Marshal.FreeHGlobal(namep);
		return ret;
	}
	internal LogStatStruct log_stat(uint flags) {
		int err = 0;
		IntPtr ptr = log_stat(flags, ref err);
		DatabaseException.ThrowException(err);
		LogStatStruct ret = (LogStatStruct)Marshal.PtrToStructure(ptr, typeof(LogStatStruct));
		libdb_csharp.__os_ufree(null, ptr);
		return ret;
	}
	internal MempStatStruct memp_stat(uint flags) {
		int err = 0;
	        int cnt = 0;
        	IntPtr mpf = new IntPtr();
	        IntPtr ptr = memp_stat(ref mpf, flags, ref err, ref cnt);
		DatabaseException.ThrowException(err);
        	IntPtr[] files = new IntPtr[cnt];
		if (cnt > 0)
	        	Marshal.Copy(mpf, files, 0, cnt);

	        MempStatStruct ret = new MempStatStruct();
		ret.st = (MPoolStatStruct)Marshal.PtrToStructure(ptr, typeof(MPoolStatStruct));
        	ret.files = new MPoolFileStatStruct[cnt];
	        for (int i = 0; i < cnt; i++)
        	    ret.files[i] = (MPoolFileStatStruct)Marshal.PtrToStructure(files[i], typeof(MPoolFileStatStruct));

		libdb_csharp.__os_ufree(null, ptr);
		libdb_csharp.__os_ufree(null, mpf);
		return ret;
	}
	internal MutexStatStruct mutex_stat(uint flags) {
		int err = 0;
		IntPtr ptr = mutex_stat(flags, ref err);
		DatabaseException.ThrowException(err);
		MutexStatStruct ret = (MutexStatStruct)Marshal.PtrToStructure(ptr, typeof(MutexStatStruct));
		libdb_csharp.__os_ufree(null, ptr);
		return ret;
	}
	internal int repmgr_get_local_site(out string hostp, ref uint portp) {
		int ret;
		IntPtr hp;
		hostp = null;
		portp = 0;
		ret = repmgr_get_local_site(out hp, ref portp);		
		hostp = Marshal.PtrToStringAnsi(hp);
		return ret;
	}
	internal RepMgrSite[] repmgr_site_list() {
		uint count = 0;
		int err = 0;
		uint size = 0;
		RepMgrSite[] ret = repmgr_site_list(ref count, ref size, ref err);
		DatabaseException.ThrowException(err);
		return ret;
	}
	internal RepMgrStatStruct repmgr_stat(uint flags) {
		int err = 0;
		IntPtr ptr = repmgr_stat(flags, ref err);
		DatabaseException.ThrowException(err);
		RepMgrStatStruct ret = (RepMgrStatStruct)Marshal.PtrToStructure(ptr, typeof(RepMgrStatStruct));
		libdb_csharp.__os_ufree(null, ptr);
		return ret;
	}
	internal ReplicationStatStruct rep_stat(uint flags) {
		int err = 0;
		IntPtr ptr = rep_stat(flags, ref err);
		DatabaseException.ThrowException(err);
		ReplicationStatStruct ret = (ReplicationStatStruct)Marshal.PtrToStructure(ptr, typeof(ReplicationStatStruct));
		libdb_csharp.__os_ufree(null, ptr);
		return ret;
	}
	internal DB_TXN txn_begin(DB_TXN parent, uint flags) {
		int err = 0;
		DB_TXN ret = txn_begin(parent, flags, ref err);
		DatabaseException.ThrowException(err);
		return ret;
	}
	internal PreparedTransaction[] txn_recover(uint count, uint flags) {
		int err = 0;
		IntPtr prepp = Marshal.AllocHGlobal((int)(count * (IntPtr.Size + DbConstants.DB_GID_SIZE)));
		uint sz = 0;
		err = txn_recover(prepp, count, ref sz, flags);
		DatabaseException.ThrowException(err);
		PreparedTransaction[] ret = new PreparedTransaction[sz];
		for (int i = 0; i < sz; i++) {
			IntPtr cPtr = new IntPtr((IntPtr.Size == 4 ? prepp.ToInt32() : prepp.ToInt64()) + i * (IntPtr.Size + DbConstants.DB_GID_SIZE));
			DB_PREPLIST prep = new DB_PREPLIST(cPtr, false);
			ret[i] = new PreparedTransaction(prep);
		}
		Marshal.FreeHGlobal(prepp);
		return ret;
	}
	internal TxnStatStruct txn_stat(uint flags) {
		int err = 0;
		uint size = 0;
		int offset = Marshal.SizeOf(typeof(DB_TXN_ACTIVE));
		IntPtr ptr = txn_stat(flags, ref size, ref err);
		DatabaseException.ThrowException(err);
	        TxnStatStruct ret = new TxnStatStruct();
		ret.st = (TransactionStatStruct)Marshal.PtrToStructure(ptr, typeof(TransactionStatStruct));
        	ret.st_txnarray = new DB_TXN_ACTIVE[ret.st.st_nactive];
	        ret.st_txngids = new byte[ret.st.st_nactive][];
        	ret.st_txnnames = new string[ret.st.st_nactive];

	        for (int i = 0; i < ret.st.st_nactive; i++) {
        	    IntPtr activep = new IntPtr((IntPtr.Size == 4 ? ret.st.st_txnarray.ToInt32() : ret.st.st_txnarray.ToInt64()) + i * size);
	            ret.st_txnarray[i] = (DB_TXN_ACTIVE)Marshal.PtrToStructure(activep, typeof(DB_TXN_ACTIVE));
        	    ret.st_txngids[i] = new byte[DbConstants.DB_GID_SIZE];
	            IntPtr gidp = new IntPtr((IntPtr.Size == 4 ? activep.ToInt32() : activep.ToInt64()) + offset);
        	    Marshal.Copy(gidp, ret.st_txngids[i], 0, (int)DbConstants.DB_GID_SIZE);
	            IntPtr namep = new IntPtr((IntPtr.Size == 4 ? gidp.ToInt32() : gidp.ToInt64()) + DbConstants.DB_GID_SIZE);
        	    ret.st_txnnames[i] = Marshal.PtrToStringAnsi(namep);
	        }
        	libdb_csharp.__os_ufree(null, ptr);
        
		return ret;
	}
	internal int get_home(out string file) {
		int ret;
		IntPtr fp;
		ret = get_home(out fp);
		file = Marshal.PtrToStringAnsi(fp);
		return ret;
	}	
	internal int get_intermediate_dir_mode(out string mode) {
		int ret;
		IntPtr mp;
		ret = get_intermediate_dir_mode(out mp);
		mode = Marshal.PtrToStringAnsi(mp);	
		return ret;
	}
	internal int get_lg_dir(out string dir) {
		int ret;
		IntPtr dirp;
		ret = get_lg_dir(out dirp);
		dir = Marshal.PtrToStringAnsi(dirp);
		return ret;
	}
	internal int get_tmp_dir(out string dir) {
		int ret;
		IntPtr dirp;
		ret = get_tmp_dir(out dirp);
		dir = Marshal.PtrToStringAnsi(dirp);
		return ret;
	}
	

  internal DatabaseEnvironment api2_internal {
    set {
      libdb_csharpPINVOKE.DB_ENV_api2_internal_set(swigCPtr, value);
    } 
		get { return libdb_csharpPINVOKE.DB_ENV_api2_internal_get(swigCPtr); }

  }

  internal int set_usercopy(DBTCopyDelegate dbt_usercopy) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_set_usercopy(swigCPtr, dbt_usercopy);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal DB_ENV(uint flags) : this(libdb_csharpPINVOKE.new_DB_ENV(flags), true) {
  }

  private DB_TXN cdsgroup_begin(ref int err) {
    IntPtr cPtr = libdb_csharpPINVOKE.DB_ENV_cdsgroup_begin(swigCPtr, ref err);
    DB_TXN ret = (cPtr == IntPtr.Zero) ? null : new DB_TXN(cPtr, false);
    return ret;
  }

  internal int close(uint flags) {
		int ret = libdb_csharpPINVOKE.DB_ENV_close(swigCPtr, flags);
		if (ret == 0)
			/* Close is a db handle destructor.  Reflect that in the wrapper class. */
			swigCPtr = new HandleRef(null, IntPtr.Zero);
		else
			DatabaseException.ThrowException(ret);
		return ret;
}

  internal int dbremove(DB_TXN txn, string file, string database, uint flags) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_dbremove(swigCPtr, DB_TXN.getCPtr(txn), file, database, flags);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int dbrename(DB_TXN txn, string file, string database, string newname, uint flags) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_dbrename(swigCPtr, DB_TXN.getCPtr(txn), file, database, newname, flags);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int failchk(uint flags) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_failchk(swigCPtr, flags);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int fileid_reset(string file, uint flags) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_fileid_reset(swigCPtr, file, flags);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int get_home(out IntPtr file) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_get_home(swigCPtr, out file);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int is_transaction_applied(DB_TXN_TOKEN token, uint timeout, uint flags) {
		return libdb_csharpPINVOKE.DB_ENV_is_transaction_applied(swigCPtr, DB_TXN_TOKEN.getCPtr(token), timeout, flags);
}

  internal int lock_detect(uint flags, uint atype, ref uint rejected) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_lock_detect(swigCPtr, flags, atype, ref rejected);
		DatabaseException.ThrowException(ret);
		return ret;
}

  private DB_LOCK lock_get(uint locker, uint flags, DatabaseEntry arg2, db_lockmode_t mode, ref int err) {
    try {
      DB_LOCK ret = new DB_LOCK(libdb_csharpPINVOKE.DB_ENV_lock_get(swigCPtr, locker, flags, DBT.getCPtr(DatabaseEntry.getDBT(arg2)), (int)mode, ref err), true);
      return ret;
    } finally {
      GC.KeepAlive(arg2);
    }
  }

  internal int lock_id(ref uint id) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_lock_id(swigCPtr, ref id);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int lock_id_free(uint id) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_lock_id_free(swigCPtr, id);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int lock_put(DB_LOCK lck) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_lock_put(swigCPtr, DB_LOCK.getCPtr(lck));
		DatabaseException.ThrowException(ret);
		return ret;
}

  private IntPtr lock_stat(uint flags, ref int err) {
	return libdb_csharpPINVOKE.DB_ENV_lock_stat(swigCPtr, flags, ref err);
}

  internal int lock_stat_print(uint flags) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_lock_stat_print(swigCPtr, flags);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int lock_vec(uint locker, uint flags, IntPtr[] list, int nlist, DB_LOCKREQ elistp) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_lock_vec(swigCPtr, locker, flags, list, nlist, DB_LOCKREQ.getCPtr(elistp));
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal List<string> log_archive(uint flags, ref int err, ref int cntp) {
	IntPtr cPtr = libdb_csharpPINVOKE.DB_ENV_log_archive(swigCPtr, flags, ref err, ref cntp);
	List<string> ret = new List<string>();
	if (cPtr == IntPtr.Zero)
		return ret;

	IntPtr[] strs = new IntPtr[cntp];
	Marshal.Copy(cPtr, strs, 0, cntp);

	for (int i =0; i < cntp; i++)
		ret.Add(Marshal.PtrToStringAnsi(strs[i]));
	libdb_csharp.__os_ufree(this, cPtr);
	return ret;
}

  private int log_file(DB_LSN lsn, IntPtr namep, uint len) {
		return libdb_csharpPINVOKE.DB_ENV_log_file(swigCPtr, DB_LSN.getCPtr(lsn), namep, len);
}

  internal int log_flush(DB_LSN lsn) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_log_flush(swigCPtr, DB_LSN.getCPtr(lsn));
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int log_put(DB_LSN lsn, DatabaseEntry data, uint flags) {
    try {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_log_put(swigCPtr, DB_LSN.getCPtr(lsn), DBT.getCPtr(DatabaseEntry.getDBT(data)), flags);
		DatabaseException.ThrowException(ret);
		return ret;
} finally {
      GC.KeepAlive(data);
    }
  }

  internal int log_get_config(uint which, ref int onoff) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_log_get_config(swigCPtr, which, ref onoff);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int log_set_config(uint which, int onoff) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_log_set_config(swigCPtr, which, onoff);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int log_printf(DB_TXN txn, string str) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_log_printf(swigCPtr, DB_TXN.getCPtr(txn), str);
		DatabaseException.ThrowException(ret);
		return ret;
}

  private IntPtr log_stat(uint flags, ref int err) {
	return libdb_csharpPINVOKE.DB_ENV_log_stat(swigCPtr, flags, ref err);
}

  internal int log_stat_print(uint flags) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_log_stat_print(swigCPtr, flags);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int lsn_reset(string file, uint flags) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_lsn_reset(swigCPtr, file, flags);
		DatabaseException.ThrowException(ret);
		return ret;
}

  private IntPtr memp_stat(ref IntPtr fstatp, uint flags, ref int err, ref int cntp) {
	return libdb_csharpPINVOKE.DB_ENV_memp_stat(swigCPtr, ref fstatp, flags, ref err, ref cntp);
}

  internal int memp_stat_print(uint flags) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_memp_stat_print(swigCPtr, flags);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int memp_sync(DB_LSN lsn) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_memp_sync(swigCPtr, DB_LSN.getCPtr(lsn));
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int memp_trickle(int percent, ref int nwrotep) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_memp_trickle(swigCPtr, percent, ref nwrotep);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int mutex_alloc(uint flags, ref uint mutexp) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_mutex_alloc(swigCPtr, flags, ref mutexp);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int mutex_free(uint mutex) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_mutex_free(swigCPtr, mutex);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int mutex_lock(uint mutex) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_mutex_lock(swigCPtr, mutex);
		DatabaseException.ThrowException(ret);
		return ret;
}

  private IntPtr mutex_stat(uint flags, ref int err) {
	return libdb_csharpPINVOKE.DB_ENV_mutex_stat(swigCPtr, flags, ref err);
}

  internal int mutex_stat_print(uint flags) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_mutex_stat_print(swigCPtr, flags);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int mutex_unlock(uint mutex) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_mutex_unlock(swigCPtr, mutex);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int mutex_get_align(ref uint align) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_mutex_get_align(swigCPtr, ref align);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int mutex_set_align(uint align) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_mutex_set_align(swigCPtr, align);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int mutex_get_increment(ref uint increment) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_mutex_get_increment(swigCPtr, ref increment);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int mutex_set_increment(uint increment) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_mutex_set_increment(swigCPtr, increment);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int mutex_get_max(ref uint max) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_mutex_get_max(swigCPtr, ref max);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int mutex_set_max(uint max) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_mutex_set_max(swigCPtr, max);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int mutex_get_tas_spins(ref uint tas_spins) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_mutex_get_tas_spins(swigCPtr, ref tas_spins);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int mutex_set_tas_spins(uint tas_spins) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_mutex_set_tas_spins(swigCPtr, tas_spins);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int open(string home, uint flags, int mode) {
	int ret;
	ret = libdb_csharpPINVOKE.DB_ENV_open(swigCPtr, home, flags, mode);
	if (ret != 0)
		close(0);
	DatabaseException.ThrowException(ret);
	return ret;
}

  internal int get_open_flags(ref uint flags) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_get_open_flags(swigCPtr, ref flags);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int remove(string db_home, uint flags) {
	int ret;
	ret = libdb_csharpPINVOKE.DB_ENV_remove(swigCPtr, db_home, flags);
	/* 
	 * remove is a handle destructor, regardless of whether the remove
	 * succeeds.  Reflect that in the wrapper class. 
	 */
	swigCPtr = new HandleRef(null, IntPtr.Zero);
	DatabaseException.ThrowException(ret);
	return ret;
}

  internal int repmgr_add_remote_site(string host, uint port, ref int eidp, uint flags) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_repmgr_add_remote_site(swigCPtr, host, port, ref eidp, flags);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int repmgr_set_ack_policy(int ack_policy) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_repmgr_set_ack_policy(swigCPtr, ack_policy);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int repmgr_get_ack_policy(ref int ack_policy) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_repmgr_get_ack_policy(swigCPtr, ref ack_policy);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int repmgr_get_local_site(out IntPtr host, ref uint port) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_repmgr_get_local_site(swigCPtr, out host, ref port);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int repmgr_set_local_site(string host, uint port, uint flags) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_repmgr_set_local_site(swigCPtr, host, port, flags);
		DatabaseException.ThrowException(ret);
		return ret;
}

  private RepMgrSite[] repmgr_site_list(ref uint countp, ref uint sizep, ref int err) {
	IntPtr cPtr = libdb_csharpPINVOKE.DB_ENV_repmgr_site_list(swigCPtr, ref countp, ref sizep, ref err);
	if (cPtr == IntPtr.Zero)
		return new RepMgrSite[] { null };
	/*
	 * This is a big kludgy, but we need to free the memory that
	 * repmgr_site_list mallocs.  The RepMgrSite constructors will copy all
	 * the data out of that malloc'd area and we can free it right away.
	 * This is easier than trying to construct a SWIG generated object that
	 * will copy everything in it's constructor, because SWIG generated
	 * classes come with a lot of baggage.
	 */	
	RepMgrSite[] ret = new RepMgrSite[countp];
	for (int i = 0; i < countp; i++) {
		/*
		 * We're copying data out of an array of countp DB_REPMGR_SITE
		 * structures, whose size varies between 32- and 64-bit
		 * platforms.  
		 */
		IntPtr val = new IntPtr((IntPtr.Size == 4 ? cPtr.ToInt32() : cPtr.ToInt64()) + i * sizep);
		ret[i] = new RepMgrSite(new DB_REPMGR_SITE(val, false));
	}
	libdb_csharp.__os_ufree(this, cPtr);
	return ret;
}

  internal int repmgr_start(int nthreads, uint flags) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_repmgr_start(swigCPtr, nthreads, flags);
		DatabaseException.ThrowException(ret);
		return ret;
}

  private IntPtr repmgr_stat(uint flags, ref int err) {
	return libdb_csharpPINVOKE.DB_ENV_repmgr_stat(swigCPtr, flags, ref err);
}

  internal int repmgr_stat_print(uint flags) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_repmgr_stat_print(swigCPtr, flags);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int rep_elect(uint nsites, uint nvotes, uint flags) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_rep_elect(swigCPtr, nsites, nvotes, flags);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int rep_process_message(DatabaseEntry control, DatabaseEntry rec, int envid, DB_LSN ret_lsnp) {
    try {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_rep_process_message(swigCPtr, DBT.getCPtr(DatabaseEntry.getDBT(control)), DBT.getCPtr(DatabaseEntry.getDBT(rec)), envid, DB_LSN.getCPtr(ret_lsnp));
		DatabaseException.ThrowException(ret);
		return ret;
} finally {
      GC.KeepAlive(control);
      GC.KeepAlive(rec);
    }
  }

  internal int rep_start(DatabaseEntry cdata, uint flags) {
    try {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_rep_start(swigCPtr, DBT.getCPtr(DatabaseEntry.getDBT(cdata)), flags);
		DatabaseException.ThrowException(ret);
		return ret;
} finally {
      GC.KeepAlive(cdata);
    }
  }

  private IntPtr rep_stat(uint flags, ref int err) {
	return libdb_csharpPINVOKE.DB_ENV_rep_stat(swigCPtr, flags, ref err);
}

  internal int rep_stat_print(uint flags) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_rep_stat_print(swigCPtr, flags);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int rep_sync(uint flags) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_rep_sync(swigCPtr, flags);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int rep_set_config(uint which, int onoff) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_rep_set_config(swigCPtr, which, onoff);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int rep_get_config(uint which, ref int onoffp) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_rep_get_config(swigCPtr, which, ref onoffp);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int rep_set_clockskew(uint fast_clock, uint slow_clock) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_rep_set_clockskew(swigCPtr, fast_clock, slow_clock);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int rep_get_clockskew(ref uint fast_clockp, ref uint slow_clockp) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_rep_get_clockskew(swigCPtr, ref fast_clockp, ref slow_clockp);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int rep_set_limit(uint gbytes, uint bytes) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_rep_set_limit(swigCPtr, gbytes, bytes);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int rep_get_limit(ref uint gbytesp, ref uint bytesp) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_rep_get_limit(swigCPtr, ref gbytesp, ref bytesp);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int rep_set_nsites(uint nsites) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_rep_set_nsites(swigCPtr, nsites);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int rep_get_nsites(ref uint nsitesp) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_rep_get_nsites(swigCPtr, ref nsitesp);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int rep_set_priority(uint priority) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_rep_set_priority(swigCPtr, priority);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int rep_get_priority(ref uint priorityp) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_rep_get_priority(swigCPtr, ref priorityp);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int rep_set_request(uint min, uint max) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_rep_set_request(swigCPtr, min, max);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int rep_get_request(ref uint minp, ref uint maxp) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_rep_get_request(swigCPtr, ref minp, ref maxp);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int rep_set_timeout(int which, uint timeout) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_rep_set_timeout(swigCPtr, which, timeout);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int rep_get_timeout(int which, ref uint timeoutp) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_rep_get_timeout(swigCPtr, which, ref timeoutp);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int rep_set_transport(int envid, BDB_RepTransportDelegate send) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_rep_set_transport(swigCPtr, envid, send);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int get_cachesize(ref uint gbytes, ref uint bytes, ref int ncache) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_get_cachesize(swigCPtr, ref gbytes, ref bytes, ref ncache);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int set_cachesize(uint gbytes, uint bytes, int ncache) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_set_cachesize(swigCPtr, gbytes, bytes, ncache);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int get_cache_max(ref uint gbytes, ref uint bytes) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_get_cache_max(swigCPtr, ref gbytes, ref bytes);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int set_cache_max(uint gbytes, uint bytes) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_set_cache_max(swigCPtr, gbytes, bytes);
		DatabaseException.ThrowException(ret);
		return ret;
}

  private List<string> get_data_dirs(ref int err, ref int cntp) {
	IntPtr cPtr = libdb_csharpPINVOKE.DB_ENV_get_data_dirs(swigCPtr, ref err, ref cntp);
	List<string> ret = new List<string>();
	if (cPtr == IntPtr.Zero)
		return ret;

	IntPtr[] strs = new IntPtr[cntp];
	Marshal.Copy(cPtr, strs, 0, cntp);

	for (int i =0; i < cntp; i++)
		ret.Add(Marshal.PtrToStringAnsi(strs[i]));

	return ret;
}

  internal int add_data_dir(string dir) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_add_data_dir(swigCPtr, dir);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int set_create_dir(string dir) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_set_create_dir(swigCPtr, dir);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int get_encrypt_flags(ref uint flags) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_get_encrypt_flags(swigCPtr, ref flags);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int set_encrypt(string passwd, uint flags) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_set_encrypt(swigCPtr, passwd, flags);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal void set_errcall(BDB_ErrcallDelegate db_errcall_fcn) {
    libdb_csharpPINVOKE.DB_ENV_set_errcall(swigCPtr, db_errcall_fcn);
  }

  internal int set_event_notify(BDB_EventNotifyDelegate callback) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_set_event_notify(swigCPtr, callback);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int set_feedback(BDB_EnvFeedbackDelegate callback) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_set_feedback(swigCPtr, callback);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int get_flags(ref uint flags) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_get_flags(swigCPtr, ref flags);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int set_flags(uint flags, int onoff) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_set_flags(swigCPtr, flags, onoff);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int get_intermediate_dir_mode(out IntPtr mode) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_get_intermediate_dir_mode(swigCPtr, out mode);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int set_intermediate_dir_mode(string mode) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_set_intermediate_dir_mode(swigCPtr, mode);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int set_isalive(BDB_IsAliveDelegate callback) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_set_isalive(swigCPtr, callback);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int get_lg_bsize(ref uint bsize) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_get_lg_bsize(swigCPtr, ref bsize);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int set_lg_bsize(uint bsize) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_set_lg_bsize(swigCPtr, bsize);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int get_lg_dir(out IntPtr dir) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_get_lg_dir(swigCPtr, out dir);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int set_lg_dir(string dir) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_set_lg_dir(swigCPtr, dir);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int get_lg_filemode(ref int mode) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_get_lg_filemode(swigCPtr, ref mode);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int set_lg_filemode(int mode) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_set_lg_filemode(swigCPtr, mode);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int get_lg_max(ref uint max) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_get_lg_max(swigCPtr, ref max);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int set_lg_max(uint max) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_set_lg_max(swigCPtr, max);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int get_lg_regionmax(ref uint max) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_get_lg_regionmax(swigCPtr, ref max);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int set_lg_regionmax(uint max) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_set_lg_regionmax(swigCPtr, max);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int log_verify(string envhome, uint cachesz, string dbfile, string dbname, long stime, long etime, uint stfile, uint stoffset, uint efile, uint eoffset, int caf, int verbose) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_log_verify(swigCPtr, envhome, cachesz, dbfile, dbname, stime, etime, stfile, stoffset, efile, eoffset, caf, verbose);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int get_lk_conflicts_nmodes(ref int nmodes) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_get_lk_conflicts_nmodes(swigCPtr, ref nmodes);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int get_lk_conflicts(byte[,] conflicts) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_get_lk_conflicts(swigCPtr, conflicts);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int set_lk_conflicts(byte[,] conflicts, int nmodes) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_set_lk_conflicts(swigCPtr, conflicts, nmodes);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int get_lk_detect(ref uint mode) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_get_lk_detect(swigCPtr, ref mode);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int set_lk_detect(uint mode) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_set_lk_detect(swigCPtr, mode);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int get_lk_max_locks(ref uint max) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_get_lk_max_locks(swigCPtr, ref max);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int set_lk_max_locks(uint max) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_set_lk_max_locks(swigCPtr, max);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int get_lk_max_lockers(ref uint max) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_get_lk_max_lockers(swigCPtr, ref max);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int set_lk_max_lockers(uint max) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_set_lk_max_lockers(swigCPtr, max);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int get_lk_max_objects(ref uint max) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_get_lk_max_objects(swigCPtr, ref max);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int set_lk_max_objects(uint max) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_set_lk_max_objects(swigCPtr, max);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int get_lk_partitions(ref uint max) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_get_lk_partitions(swigCPtr, ref max);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int set_lk_partitions(uint max) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_set_lk_partitions(swigCPtr, max);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int get_mp_max_openfd(ref int maxopenfd) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_get_mp_max_openfd(swigCPtr, ref maxopenfd);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int set_mp_max_openfd(int maxopenfd) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_set_mp_max_openfd(swigCPtr, maxopenfd);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int get_mp_max_write(ref int maxwrite, ref uint maxwrite_sleep) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_get_mp_max_write(swigCPtr, ref maxwrite, ref maxwrite_sleep);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int set_mp_max_write(int maxwrite, uint maxwrite_sleep) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_set_mp_max_write(swigCPtr, maxwrite, maxwrite_sleep);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int get_mp_mmapsize(ref uint mp_mmapsize) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_get_mp_mmapsize(swigCPtr, ref mp_mmapsize);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int set_mp_mmapsize(uint mp_mmapsize) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_set_mp_mmapsize(swigCPtr, mp_mmapsize);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int get_thread_count(ref uint count) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_get_thread_count(swigCPtr, ref count);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int set_thread_count(uint count) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_set_thread_count(swigCPtr, count);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int set_thread_id(BDB_ThreadIDDelegate callback) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_set_thread_id(swigCPtr, callback);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int set_thread_id_string(BDB_ThreadNameDelegate callback) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_set_thread_id_string(swigCPtr, callback);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int get_timeout(ref uint timeout, uint flags) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_get_timeout(swigCPtr, ref timeout, flags);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int set_timeout(uint timeout, uint flags) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_set_timeout(swigCPtr, timeout, flags);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int get_tmp_dir(out IntPtr dir) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_get_tmp_dir(swigCPtr, out dir);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int set_tmp_dir(string dir) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_set_tmp_dir(swigCPtr, dir);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int get_tx_max(ref uint max) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_get_tx_max(swigCPtr, ref max);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int set_tx_max(uint max) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_set_tx_max(swigCPtr, max);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int get_tx_timestamp(ref long timestamp) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_get_tx_timestamp(swigCPtr, ref timestamp);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int set_tx_timestamp(ref long timestamp) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_set_tx_timestamp(swigCPtr, ref timestamp);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int get_verbose(ref uint msgs) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_get_verbose(swigCPtr, ref msgs);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int set_verbose(uint which, int onoff) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_set_verbose(swigCPtr, which, onoff);
		DatabaseException.ThrowException(ret);
		return ret;
}

  internal int stat_print(uint flags) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_stat_print(swigCPtr, flags);
		DatabaseException.ThrowException(ret);
		return ret;
}

  private DB_TXN txn_begin(DB_TXN parent, uint flags, ref int err) {
    IntPtr cPtr = libdb_csharpPINVOKE.DB_ENV_txn_begin(swigCPtr, DB_TXN.getCPtr(parent), flags, ref err);
    DB_TXN ret = (cPtr == IntPtr.Zero) ? null : new DB_TXN(cPtr, false);
    return ret;
  }

  internal int txn_checkpoint(uint kbyte, uint min, uint flags) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_txn_checkpoint(swigCPtr, kbyte, min, flags);
		DatabaseException.ThrowException(ret);
		return ret;
}

  private int txn_recover(IntPtr preplist, uint count, ref uint retp, uint flags) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_txn_recover(swigCPtr, preplist, count, ref retp, flags);
		DatabaseException.ThrowException(ret);
		return ret;
}

  private IntPtr txn_stat(uint flags, ref uint size, ref int err) {
	return libdb_csharpPINVOKE.DB_ENV_txn_stat(swigCPtr, flags, ref size, ref err);
}

  internal int txn_stat_print(uint flags) {
		int ret;
		ret = libdb_csharpPINVOKE.DB_ENV_txn_stat_print(swigCPtr, flags);
		DatabaseException.ThrowException(ret);
		return ret;
}

}

}
