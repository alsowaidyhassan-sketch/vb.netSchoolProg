import React, { useState } from 'react';
import {
  X,
  MoreVertical,
  RotateCw,
  LayoutDashboard,
  GraduationCap,
  Users,
  School,
  BookOpen,
  CalendarCheck,
  FileCheck2,
  Receipt,
  Briefcase,
  BarChart3,
  ShieldAlert,
  DatabaseBackup,
  History,
  Settings,
  FolderGit2,
  Layers
} from 'lucide-react';
import { TabItem, ModuleKey } from '../../types';

interface TabControlProps {
  tabs: TabItem[];
  activeTabId: ModuleKey;
  onSelectTab: (id: ModuleKey) => void;
  onCloseTab: (id: ModuleKey) => void;
  onCloseOtherTabs: (id: ModuleKey) => void;
  onCloseAllTabs: () => void;
  onRefreshTab: () => void;
}

const getTabIcon = (id: ModuleKey) => {
  switch (id) {
    case 'dashboard':
      return <LayoutDashboard className="w-3.5 h-3.5" />;
    case 'students':
      return <GraduationCap className="w-3.5 h-3.5" />;
    case 'teachers':
      return <Users className="w-3.5 h-3.5" />;
    case 'classes':
      return <School className="w-3.5 h-3.5" />;
    case 'subjects':
      return <BookOpen className="w-3.5 h-3.5" />;
    case 'attendance':
      return <CalendarCheck className="w-3.5 h-3.5" />;
    case 'exams':
      return <FileCheck2 className="w-3.5 h-3.5" />;
    case 'finance':
      return <Receipt className="w-3.5 h-3.5" />;
    case 'hr':
      return <Briefcase className="w-3.5 h-3.5" />;
    case 'reports':
      return <BarChart3 className="w-3.5 h-3.5" />;
    case 'users':
      return <ShieldAlert className="w-3.5 h-3.5" />;
    case 'backup':
      return <DatabaseBackup className="w-3.5 h-3.5" />;
    case 'audit':
      return <History className="w-3.5 h-3.5" />;
    case 'settings':
      return <Settings className="w-3.5 h-3.5" />;
    case 'solution':
      return <FolderGit2 className="w-3.5 h-3.5 text-cyan-400" />;
    default:
      return <Layers className="w-3.5 h-3.5" />;
  }
};

export const TabControl: React.FC<TabControlProps> = ({
  tabs,
  activeTabId,
  onSelectTab,
  onCloseTab,
  onCloseOtherTabs,
  onCloseAllTabs,
  onRefreshTab
}) => {
  const [showContextMenu, setShowContextMenu] = useState(false);

  return (
    <div
      id="desktop-tabcontrol"
      className="h-10 bg-slate-950/80 border-b border-slate-800 flex items-center justify-between px-2 gap-2 z-20 shrink-0 select-none"
    >
      {/* Scrollable Tabs List */}
      <div className="flex-1 flex items-center gap-1 overflow-x-auto no-scrollbar py-1">
        {tabs.map((tab) => {
          const isActive = activeTabId === tab.id;
          return (
            <div
              key={tab.id}
              onClick={() => onSelectTab(tab.id)}
              className={`group flex items-center gap-2 px-3 py-1.5 rounded-lg text-xs font-semibold transition-all cursor-pointer border shrink-0 ${
                isActive
                  ? 'bg-slate-800 text-blue-400 border-slate-700 shadow-sm'
                  : 'bg-slate-900/60 text-slate-400 border-transparent hover:bg-slate-900 hover:text-slate-200'
              }`}
            >
              <span className={isActive ? 'text-blue-400' : 'text-slate-500 group-hover:text-slate-300'}>
                {getTabIcon(tab.id)}
              </span>

              <span className="truncate max-w-[140px]">{tab.title}</span>

              {/* Close Button (Disabled on pinned Dashboard) */}
              {!tab.isPinned && (
                <button
                  onClick={(e) => {
                    e.stopPropagation();
                    onCloseTab(tab.id);
                  }}
                  className="p-0.5 rounded-md hover:bg-slate-700 text-slate-500 hover:text-red-400 transition-colors"
                  title="إغلاق هذا التبويب"
                >
                  <X className="w-3 h-3" />
                </button>
              )}
            </div>
          );
        })}
      </div>

      {/* Tab Context Actions Menu */}
      <div className="relative">
        <button
          onClick={() => setShowContextMenu(!showContextMenu)}
          className="p-1.5 rounded-lg bg-slate-900 hover:bg-slate-800 text-slate-400 hover:text-slate-200 border border-slate-800 transition-colors"
          title="خيارات التبويبات"
        >
          <MoreVertical className="w-3.5 h-3.5" />
        </button>

        {showContextMenu && (
          <div className="absolute left-0 mt-1 w-48 bg-slate-900 border border-slate-700 rounded-xl shadow-2xl p-1 z-50 text-xs animate-in fade-in zoom-in-95 duration-100">
            <button
              onClick={() => {
                onRefreshTab();
                setShowContextMenu(false);
              }}
              className="w-full flex items-center gap-2 px-3 py-2 text-slate-300 hover:bg-slate-800 hover:text-white rounded-lg transition-colors text-right"
            >
              <RotateCw className="w-3.5 h-3.5 text-blue-400" />
              <span>تحديث التبويب الحالي</span>
            </button>

            {activeTabId !== 'dashboard' && (
              <button
                onClick={() => {
                  onCloseTab(activeTabId);
                  setShowContextMenu(false);
                }}
                className="w-full flex items-center gap-2 px-3 py-2 text-slate-300 hover:bg-slate-800 hover:text-white rounded-lg transition-colors text-right"
              >
                <X className="w-3.5 h-3.5 text-amber-400" />
                <span>إغلاق التبويب الحالي</span>
              </button>
            )}

            <button
              onClick={() => {
                onCloseOtherTabs(activeTabId);
                setShowContextMenu(false);
              }}
              className="w-full flex items-center gap-2 px-3 py-2 text-slate-300 hover:bg-slate-800 hover:text-white rounded-lg transition-colors text-right"
            >
              <Layers className="w-3.5 h-3.5 text-slate-400" />
              <span>إغلاق التبويبات الأخرى</span>
            </button>

            <div className="border-t border-slate-800 my-1"></div>

            <button
              onClick={() => {
                onCloseAllTabs();
                setShowContextMenu(false);
              }}
              className="w-full flex items-center gap-2 px-3 py-2 text-red-400 hover:bg-red-950/40 hover:text-red-300 rounded-lg transition-colors text-right font-semibold"
            >
              <X className="w-3.5 h-3.5" />
              <span>إغلاق الكل (عدا الرئيسية)</span>
            </button>
          </div>
        )}
      </div>
    </div>
  );
};
